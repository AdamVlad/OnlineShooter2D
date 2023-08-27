using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.LobbyScene.Model
{
    public class RoomListEntry : MonoBehaviour
    {
        [SerializeField] private Text _roomNameText;
        [SerializeField] private Text _roomPlayersText;
        [SerializeField] private Button _joinRoomButton;

        private string _roomName;

        public void Start()
        {
            _joinRoomButton.onClick.AddListener(() =>
            {
                if (PhotonNetwork.NetworkingClient.State is
                    ClientState.Authenticating or
                    ClientState.ConnectingToGameServer or
                    ClientState.ConnectingToMasterServer or
                    ClientState.JoiningLobby or
                    ClientState.Joining)
                {
                    return;
                }

                PhotonNetwork.JoinRoom(_roomName);
            });
        }

        public void Initialize(string name, byte currentPlayers, byte maxPlayers)
        {
            _roomName = name;

            _roomNameText.text = name;
            _roomPlayersText.text = currentPlayers + " / " + maxPlayers;
        }
    }
}