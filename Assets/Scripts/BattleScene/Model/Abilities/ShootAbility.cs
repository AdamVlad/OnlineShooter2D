using Assets.Scripts.BattleScene.Model.Abilities.Interfaces;
using Assets.Scripts.BattleScene.Model.Settings;
using Photon.Pun;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.Abilities
{
    [RequireComponent(typeof(PhotonView))]
    internal sealed class ShootAbility : MonoBehaviour, IShootAbility
    {
        [SerializeField] private PlayerSettings _playerSettings;

        private PhotonView _photonView;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        [PunRPC]
        public void Shoot(Vector3 position, Vector2 direction)
        {
            var shiftedPosition = new Vector3(position.x, position.y + 0.7f, position.z);
            var bullet = Instantiate(_playerSettings.Bullet, shiftedPosition, Quaternion.identity);
            bullet.Initialize(direction, _photonView.Owner, _playerSettings.ShootPower, _playerSettings.ShootDamage);
        }
    }
}