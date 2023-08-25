using Assets.Scripts.BattleScene.Model.Settings;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Assets.Scripts.BattleScene.ViewModel
{
    [RequireComponent(
        typeof(Rigidbody2D),
        typeof(CircleCollider2D))]
    internal class BulletViewModel : MonoBehaviour
    {
        [SerializeField] private PlayerSettings _playerSettings;

        public void Initialize(Vector2 direction, Player owner)
        {
            _direction = direction.normalized;
            _owner = owner;
        }

        private void Start()
        {
            Destroy(gameObject, 3.0f);
        }

        private void FixedUpdate()
        {
            transform.position += new Vector3(
                _direction.x * _playerSettings.ShootPower,
                _direction.y * _playerSettings.ShootPower,
                0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PhotonView>(out var photonView))
            {
                if (Equals(photonView.Owner, _owner)) return;
            }

            Destroy(gameObject);
        }

        private Vector2 _direction;
        private Player _owner;
    }
}
