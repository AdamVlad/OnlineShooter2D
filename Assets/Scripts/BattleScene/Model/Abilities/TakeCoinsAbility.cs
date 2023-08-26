using System;
using Assets.Scripts.BattleScene.Model.Abilities.Interfaces;
using Assets.Scripts.BattleScene.ViewModel.Bars;
using Assets.Scripts.BattleScene.ViewModel.Bars.Interfaces;
using Photon.Pun;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.Abilities
{
    [RequireComponent(typeof(PhotonView))]
    internal sealed class TakeCoinsAbility : MonoBehaviour, ITakeCoinsAbility
    {
        [SerializeField] private float _maxPickedUpCoinsPrice;

        public float CurrentCoins { get; private set; }

        private PhotonView _photonView;
        private ICoinsViewModel _coinsViewModel;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();

            InitializeCoinsBar();
        }

        public void TakeCoin(float price)
        {
            if (!_photonView.AmOwner || price < 0) return;

            CurrentCoins += price;
            if (CurrentCoins > _maxPickedUpCoinsPrice)
            {
                CurrentCoins = _maxPickedUpCoinsPrice;
            }

            if (_coinsViewModel == null) return;

            _coinsViewModel.Fill = (Single)(CurrentCoins / _maxPickedUpCoinsPrice);
        }

        private void InitializeCoinsBar()
        {
            if (_photonView.AmOwner)
            {
                _coinsViewModel = GameObject.Find("HudCanvas").GetComponent<CoinsBarViewModel>();
                CurrentCoins = 0;
                _coinsViewModel.Fill = (Single)CurrentCoins;
            }
        }
    }
}