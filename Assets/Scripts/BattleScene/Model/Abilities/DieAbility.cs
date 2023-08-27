using Assets.Scripts.LobbyScene.Model.Network;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.Abilities
{
    [RequireComponent(
        typeof(PhotonView),
        typeof(CapsuleCollider2D))]
    internal sealed class DieAbility : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderer;
        [SerializeField, Tooltip("This objects will be disabled on the remote user. " +
                                 "They will not be disabled on the local user")] 
        private GameObject[] _toDeactivateObjectsBeforeDie;

        [SerializeField, Tooltip("This mono will be disabled on the local user. " +
                                 "They will not be disabled on the remote user")] 
        private MonoBehaviour[] _toDeactivateMonoBehaviourBeforeDie;

        private PhotonView _photonView;
        private Collider2D _collider;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            _collider = GetComponent<CapsuleCollider2D>();
        }

        [PunRPC]
        public void Die()
        {
            _collider.enabled = false;
            foreach (var renderer in _renderer)
            {
                renderer.enabled = false;
            }
            foreach (var toDeactivateMono in _toDeactivateMonoBehaviourBeforeDie)
            {
                toDeactivateMono.enabled = false;
            }

            if (!_photonView.IsMine)
            {
                foreach (var toDeactivateGo in _toDeactivateObjectsBeforeDie)
                {
                    toDeactivateGo?.SetActive(false);
                }
                return;
            }
            
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(NetworkPlayerInfo.IsAlive, out _))
            {
                PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable
                {
                    { NetworkPlayerInfo.IsAlive, false }
                });
            }
        }
    }
}