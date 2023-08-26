using Assets.Scripts.BattleScene.Model.Abilities.Interfaces;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model
{
    [RequireComponent(
        typeof(Rigidbody2D),
        typeof(CircleCollider2D))]
    internal class BulletModel : MonoBehaviour
    {
        public void Initialize(
            Vector2 direction,
            Player owner,
            float shootPower,
            float damage)
        {
            _direction = direction.normalized;
            _owner = owner;
            _shootPower = shootPower;
            _damage = damage;
        }

        private void Start()
        {
            Destroy(gameObject, 3.0f);
        }

        private void FixedUpdate()
        {
            transform.position += new Vector3(
                _direction.x * _shootPower,
                _direction.y * _shootPower,
                0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PhotonView>(out var photonView))
            {
                if (Equals(photonView.Owner, _owner)) return;

                if (Equals(photonView.Owner, PhotonNetwork.LocalPlayer) && 
                    other.TryGetComponent<ITakeDamageAbility>(out _))
                {
                    photonView.RPC("TakeDamage", RpcTarget.AllViaServer, _damage);
                }
            }

            Destroy(gameObject);
        }

        private Vector2 _direction;
        private Player _owner;
        private float _shootPower;
        private float _damage;
    }
}
