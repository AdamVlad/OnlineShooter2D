using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Model
{
    internal class PlayerListEntry : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Text _playerNameText;

        public void Start()
        {
            PhotonNetwork.LocalPlayer.SetScore(0);
        }

        public void Initialize(string playerName)
        {
            _playerNameText.text = playerName;
        }
    }
}