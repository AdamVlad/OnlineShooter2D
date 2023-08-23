using System.Collections.Generic;
using Assets.Scripts.LobbyScene.Model;
using Assets.Scripts.LobbyScene.Model.Canvas.Interfaces;
using Assets.Scripts.LobbyScene.Model.Network;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.LobbyScene.ViewModel
{
    public class LauncherViewModel : MonoBehaviourPunCallbacks
    {
        [Inject] private readonly ICanvasModel _canvasModel;
        
        private Dictionary<string, RoomInfo> _cachedRoomList;
        private Dictionary<string, GameObject> _roomListEntries;
        private Dictionary<int, GameObject> _playerListEntries;

        public void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;

            _cachedRoomList = new Dictionary<string, RoomInfo>();
            _roomListEntries = new Dictionary<string, GameObject>();
        }

        public override void OnConnectedToMaster()
        {
            _canvasModel.SetActivePanel(_canvasModel.CreateOrJoinRoomPanel.Panel.name);
            JoinLobby(true);
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            ClearRoomListView();
            UpdateCachedRoomList(roomList);
            UpdateRoomListView();
        }

        public override void OnJoinedLobby()
        {
            _cachedRoomList.Clear();
            ClearRoomListView();
        }

        public override void OnLeftLobby()
        {
            _cachedRoomList.Clear();
            ClearRoomListView();
        }

        public override void OnJoinedRoom()
        {
            _cachedRoomList.Clear();

            _canvasModel.SetActivePanel(_canvasModel.InsideRoomPanel.Panel.name);

            _playerListEntries ??= new Dictionary<int, GameObject>();

            foreach (Player player in PhotonNetwork.PlayerList)
            {
                GameObject entry = Instantiate(_canvasModel.PlayerListEntryPanel.Panel);
                entry.transform.SetParent(_canvasModel.InsideRoomPanel.Panel.transform);
                entry.transform.localScale = Vector3.one;
                entry.GetComponent<PlayerListEntry>().Initialize(player.NickName);

                _playerListEntries.Add(player.ActorNumber, entry);
            }

            Hashtable props = new Hashtable
            {
                {NetworkPlayerInfo.PlayerLoadedLevel, false}
            };

            PhotonNetwork.LocalPlayer.SetCustomProperties(props);

            if (!PhotonNetwork.IsMasterClient)
            {
                _canvasModel.StartGameButton.SetActive(false);
            }

            JoinLobby(false);
        }

        public override void OnLeftRoom()
        {
            _canvasModel?.SetActivePanel(_canvasModel.CreateOrJoinRoomPanel.Panel.name);

            foreach (GameObject entry in _playerListEntries.Values)
            {
                Destroy(entry.gameObject);
            }

            _playerListEntries.Clear();
            _playerListEntries = null;

            JoinLobby(true);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            GameObject entry = Instantiate(_canvasModel.PlayerListEntryPanel.Panel);
            entry.transform.SetParent(_canvasModel.InsideRoomPanel.Panel.transform);
            entry.transform.localScale = Vector3.one;
            entry.GetComponent<PlayerListEntry>().Initialize(newPlayer.NickName);

            _playerListEntries.Add(newPlayer.ActorNumber, entry);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            if (_playerListEntries.TryGetValue(otherPlayer.ActorNumber, out var playerListEntry))
            {
                Destroy(playerListEntry);
                _playerListEntries.Remove(otherPlayer.ActorNumber);
            }
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
            {
                _canvasModel.StartGameButton.SetActive(true);
            }
        }

        private void ClearRoomListView()
        {
            foreach (GameObject entry in _roomListEntries.Values)
            {
                Destroy(entry.gameObject);
            }

            _roomListEntries.Clear();
        }

        private void UpdateCachedRoomList(List<RoomInfo> roomList)
        {
            foreach (RoomInfo info in roomList)
            {
                if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
                {
                    if (_cachedRoomList.ContainsKey(info.Name))
                    {
                        _cachedRoomList.Remove(info.Name);
                    }

                    continue;
                }

                if (_cachedRoomList.ContainsKey(info.Name))
                {
                    _cachedRoomList[info.Name] = info;
                }
                else
                {
                    _cachedRoomList.Add(info.Name, info);
                }
            }
        }

        private void UpdateRoomListView()
        {
            foreach (RoomInfo info in _cachedRoomList.Values)
            {
                GameObject entry = Instantiate(_canvasModel.RoomListEntryPanel.Panel);
                entry.transform.SetParent(_canvasModel.RoomListEntryPanel.Parent.transform);
                entry.transform.localScale = Vector3.one;
                entry.GetComponent<RoomListEntry>().Initialize(info.Name, (byte)info.PlayerCount, (byte)info.MaxPlayers);

                _roomListEntries.Add(info.Name, entry);
            }
        }

        private void JoinLobby(bool value)
        {
            switch (value)
            {
                case true when !PhotonNetwork.InLobby:
                    PhotonNetwork.JoinLobby();
                    break;
                case false when PhotonNetwork.InLobby:
                    PhotonNetwork.LeaveLobby();
                    break;
            }
        }
    }
}
