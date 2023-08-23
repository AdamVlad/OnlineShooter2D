using Assets.Scripts.LobbyScene.Model.Network.Interfaces;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

namespace Assets.Scripts.LobbyScene.ViewModel.Buttons
{
    [Binding]
    internal class CreateRoomButtonViewModel : MonoBehaviour
    {
        [Inject] private readonly INetworkRoomInfo _networkRoomInfo;

        [Binding]
        public void OnClick()
        {
            string roomName = _networkRoomInfo.CreatedRoomName;
            roomName = (roomName.Equals(string.Empty)) ? "Room " + Random.Range(1000, 10000) : roomName;

            RoomOptions options = new RoomOptions { MaxPlayers = 4, PlayerTtl = 10000 };
            PhotonNetwork.CreateRoom(roomName, options);
        }
    }
}