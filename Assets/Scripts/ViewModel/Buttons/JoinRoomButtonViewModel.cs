using Assets.Scripts.Model.Network.Interfaces;
using ModestTree;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

namespace Assets.Scripts.ViewModel.Buttons
{
    [Binding]
    internal class JoinRoomButtonViewModel : MonoBehaviour
    {
        [Inject] private readonly INetworkRoomInfo _networkRoomInfo;

        [Binding]
        public void OnClick()
        {
            if (_networkRoomInfo.JoinedRoomName.IsEmpty()) return;

            RoomOptions options = new RoomOptions { MaxPlayers = 4, PlayerTtl = 10000 };
            PhotonNetwork.JoinOrCreateRoom(_networkRoomInfo.JoinedRoomName, options, null);
        }
    }
}