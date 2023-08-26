using Assets.Scripts.BattleScene.Model.Abilities.Interfaces;
using Photon.Pun;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model
{
    [RequireComponent(
        typeof(Rigidbody2D),
        typeof(CircleCollider2D),
        typeof(PhotonView))]
    internal class CoinModel : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderers;
        [SerializeField] private float _price = 1;

        private bool _isDestroyed;
        private PhotonView _photonView;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isDestroyed) return;

            if (!other.TryGetComponent<ITakeCoinsAbility>(out var ability)) return;

            ability.TakeCoin(_price);

            if (_photonView.IsMine)
            {
                DestroyCoinGlobally();
            }
            else
            {
                DestroyCoinLocally();
            }
        }

        private void DestroyCoinGlobally()
        {
            _isDestroyed = true;
            PhotonNetwork.Destroy(gameObject);
        }

        private void DestroyCoinLocally()
        {
            _isDestroyed = true;

            foreach (var renderer in _renderers)
            {
                renderer.enabled = false;
            }
        }
    }
}