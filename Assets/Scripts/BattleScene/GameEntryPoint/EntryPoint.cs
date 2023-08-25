using Assets.Scripts.BattleScene.ViewModel;
using Assets.Scripts.LobbyScene.Model.Network;

using Cinemachine;
using Photon.Pun;
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

        [SerializeField] private CinemachineVirtualCamera _camera;

        private void Start()
        {
            Hashtable props = new Hashtable
            {
                {NetworkPlayerInfo.PlayerLoadedLevel, true}
            };

            PhotonNetwork.LocalPlayer.SetCustomProperties(props);
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
            var actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
            var countSpawnPositions = _playersSpawnPositions.Length;

            if (0 < actorNumber && actorNumber <= countSpawnPositions)
            {
                var spawnPosition = _playersSpawnPositions[actorNumber - 1];

                var player = PhotonNetwork.Instantiate(
                    _playerPrefab.name,
                    spawnPosition.position,
                    Quaternion.identity);

                _camera.Follow = player.transform;
            }
            else
            {
                Debug.Log("Creating player error");
            }
        }

        private bool CheckAllPlayerLoadedLevel()
        {
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                object playerLoadedLevel;

                if (p.CustomProperties.TryGetValue(NetworkPlayerInfo.PlayerLoadedLevel, out playerLoadedLevel))
                {
                    if ((bool)playerLoadedLevel)
                    {
                        continue;
                    }
                }

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

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
            {
                //StartCoroutine(SpawnAsteroid());
            }
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            CheckEndOfGame();
        }

        private void CheckEndOfGame()
        {
            //bool allDestroyed = true;

            //foreach (Player p in PhotonNetwork.PlayerList)
            //{
            //    object lives;
            //    if (p.CustomProperties.TryGetValue(ZombielandGame.PLAYER_LIVES, out lives))
            //    {
            //        if ((int) lives > 0)
            //        {
            //            allDestroyed = false;
            //            break;
            //        }
            //    }
            //}

            //if (allDestroyed)
            //{
            //    if (PhotonNetwork.IsMasterClient)
            //    {
            //        StopAllCoroutines();
            //    }

            //    string winner = "";
            //    int score = -1;

            //    foreach (Player p in PhotonNetwork.PlayerList)
            //    {
            //        if (p.GetScore() > score)
            //        {
            //            winner = p.NickName;
            //            score = p.GetScore();
            //        }
            //    }

            //    StartCoroutine(EndOfGame(winner, score));
            //}
        }

        private bool _allPlayersLoadedLevel;
    }
}