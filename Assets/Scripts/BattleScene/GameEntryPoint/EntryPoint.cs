using Assets.Scripts.BattleScene.Model;
using Assets.Scripts.BattleScene.ViewModel;
using Assets.Scripts.LobbyScene.Model.Network;

using Cinemachine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace Assets.Scripts.BattleScene.GameEntryPoint
{
    internal class EntryPoint : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform[] _playersSpawnPositions;

        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private Transform[] _coinsSpawnPositions;

        [SerializeField] private CinemachineVirtualCamera _camera;

        [SerializeField] private WinnerTableViewModel _winnerTableViewModel;
        [SerializeField] private LooserTableViewModel _looserTableViewModel;

        private void Start()
        {
            Hashtable props = new Hashtable
            {
                {NetworkPlayerInfo.PlayerLoadedLevel, true},
                {NetworkPlayerInfo.IsAlive, true}
            };

            PhotonNetwork.LocalPlayer.SetCustomProperties(props);

            _winnerTableViewModel.gameObject.SetActive(false);
            _looserTableViewModel.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_allPlayersLoadedLevel) return;

            if (CheckAllPlayerLoadedLevel())
            {
                _allPlayersLoadedLevel = true;
                StartGame();
            }
        }

        private void StartGame()
        {
            SpawnPlayers();
            SpawnCoins();
        }

        private void SpawnPlayers()
        {
            int playerNumber = 0;
            foreach (var player in PhotonNetwork.PlayerList)
            {
                if (player.IsLocal)
                {
                    _localPlayer = PhotonNetwork.Instantiate(
                        _playerPrefab.name,
                        _playersSpawnPositions[playerNumber].position,
                        Quaternion.identity);

                    _camera.Follow = _localPlayer.transform;

                    return;
                }

                playerNumber++;
            }
        }

        private void SpawnCoins()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (var spawnPosition in _coinsSpawnPositions)
                {
                    PhotonNetwork.InstantiateRoomObject(
                        _coinPrefab.name,
                        spawnPosition.position,
                        Quaternion.identity);
                }
            }
        }

        private bool CheckAllPlayerLoadedLevel()
        {
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                object playerLoadedLevel;

                if (!p.CustomProperties.TryGetValue(
                        NetworkPlayerInfo.PlayerLoadedLevel, out playerLoadedLevel)) return false;

                if ((bool)playerLoadedLevel) continue;

                return false;
            }

            return true;
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            SceneManager.LoadScene("LobbyScene");
        }

        public override void OnLeftRoom()
        {
            PhotonNetwork.Disconnect();
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            CheckEndOfGame();
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if (changedProps.ContainsKey(NetworkPlayerInfo.IsAlive))
            {
                CheckEndOfGame();
            }
        }

        private void CheckEndOfGame()
        {
            if (_isLose) return;

            var countAlive = 0;
            Player winner = null;

            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (!player.CustomProperties
                        .TryGetValue(NetworkPlayerInfo.IsAlive, out var isAlive)) continue;

                if ((bool)isAlive)
                {
                    winner = player;
                    countAlive++;
                }
                else
                {
                    if (player.IsLocal)
                    {
                        _isLose = true;
                        EndOfGame(player.GetScore(), false);
                        return;
                    }
                }
            }

            if (countAlive == 1)
            {
                EndOfGame(winner.GetScore(), true);
            }
        }

        private void EndOfGame(int score, bool won)
        {
            if (won)
            {
                try
                {
                    _localPlayer.GetComponent<PlayerModel>().enabled = false;
                }
                catch
                {
                    Debug.Log("This exception occurs if one player enters the game, which " +
                              "leads to an automatic win, but the component does not have time to initialize");
                }

                _winnerTableViewModel.gameObject.SetActive(true);
                _winnerTableViewModel.Text = score.ToString();
            }
            else
            {
                _looserTableViewModel.gameObject.SetActive(true);
                _looserTableViewModel.Text = score.ToString();
            }
        }

        private bool _allPlayersLoadedLevel;
        private bool _isLose;
        private GameObject _localPlayer;
    }
}