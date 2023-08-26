using Assets.Scripts.LobbyScene.Model.Network;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.LobbyScene.Model
{
    internal class PlayerListEntry : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Text _playerNameText;
        [SerializeField] private Image _playerColorImage;

        private int _ownerOd;

        public void OnEnable()
        {
            PlayerNumbering.OnPlayerNumberingChanged += OnPlayerNumberingChanged;
        }

        public void OnDisable()
        {
            PlayerNumbering.OnPlayerNumberingChanged -= OnPlayerNumberingChanged;
        }

        public void Start()
        {
            PhotonNetwork.LocalPlayer.SetScore(0);
        }

        public void Initialize(string playerName, int playerId)
        {
            _playerNameText.text = playerName;
            _ownerOd = playerId;
        }

        private void OnPlayerNumberingChanged()
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.ActorNumber == _ownerOd)
                {
                    _playerColorImage.color = NetworkPlayerInfo.GetColor(player.GetPlayerNumber());
                }
            }
        }
    }
}