using Assets.Scripts.LobbyScene.Model.Network.Interfaces;
using Photon.Pun;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

namespace Assets.Scripts.LobbyScene.ViewModel.Buttons
{
    [Binding]
    internal class LoginButtonViewModel : MonoBehaviour
    {
        [Inject] private readonly INetworkPlayerInfo _networkPlayerInfo;

        [Binding]
        public void OnClick()
        {
            if (!_networkPlayerInfo.Name.Equals(""))
            {
                PhotonNetwork.LocalPlayer.NickName = _networkPlayerInfo.Name;
                PhotonNetwork.ConnectUsingSettings();
            }
            else
            {
                _networkPlayerInfo.Name = "Player " + Random.Range(1000, 10000);
            }
        }
    }
}