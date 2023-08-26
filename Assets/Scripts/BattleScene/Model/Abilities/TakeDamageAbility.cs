using System;
using Assets.Scripts.BattleScene.Extensions;
using Assets.Scripts.BattleScene.Model.Abilities.Interfaces;
using Assets.Scripts.BattleScene.ViewModel.Bars;
using Assets.Scripts.BattleScene.ViewModel.Bars.Interfaces;
using Photon.Pun;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.Abilities
{
    [RequireComponent(typeof(PhotonView))]
    internal sealed class TakeDamageAbility : MonoBehaviour, ITakeDamageAbility
    {
        private PhotonView _photonView;
        private IHpBarViewModel _hpBar;
        private float _currentHealth;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();

            InitializeHpBar();
        }

        [PunRPC]
        public void TakeDamage(float damage)
        {
            if (damage < 0) return;

            _currentHealth -= damage;
            _hpBar.Fill = (Single)(_currentHealth / 100);

            if (!_photonView.IsMine || _currentHealth > 0) return;

            _photonView.RPC("Die", RpcTarget.All);
        }

        private void InitializeHpBar()
        {
            var ownHpBar = gameObject.TryGetComponentInChildrenOrThrowException<HpBarViewModel>();

            if (!_photonView.AmOwner)
            {
                _hpBar = ownHpBar;
            }
            else
            {
                Destroy(ownHpBar.gameObject);
                ownHpBar.enabled = false;
                _hpBar = GameObject.Find("HudCanvas").GetComponent<HpBarViewModel>();
            }

            _currentHealth = 100;
            _hpBar.Fill = 1;
        }
    }
}