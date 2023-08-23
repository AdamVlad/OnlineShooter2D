using Assets.Scripts.Model.Canvas;
using Assets.Scripts.Model.Canvas.Interfaces;

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.GameEntryPoint
{
    internal sealed class CanvasInstaller : MonoInstaller
    {
        [Header("Login Panel")]
        [SerializeField]
        [FormerlySerializedAs("Login Panel")] private GameObject _loginPanel;

        [Header("Create Or JoinRoom Panel")]
        [SerializeField]
        [FormerlySerializedAs("Create Or Join Room Panel")] private GameObject _createOrJoinRoomPanel;

        [Header("Inside Room Panel")]
        [SerializeField]
        [FormerlySerializedAs("Inside Room Panel")] private GameObject _insideRoomPanel;

        [Header("Player List Entry Panel (Prefab)")]
        [SerializeField]
        [FormerlySerializedAs("Player List Entry Prefab")] private GameObject _playerListEntryPanel;

        [Header("Room List Entry Panel (Prefab)")]
        [SerializeField]
        [FormerlySerializedAs("Room List Entry Prefab")] private GameObject _roomListEntryPanel;

        [SerializeField]
        [FormerlySerializedAs("Room List Entry Parent")] private GameObject _roomListEntryParent;

        [Header("Start Game Button")]
        [SerializeField]
        [FormerlySerializedAs("Start Game Button")] private Button _startGameButton;

        public override void InstallBindings()
        {
            LoginPanelInstall();
            CreateOrJoinRoomPanelInstall();
            InsideRoomPanelInstall();
            PlayerListEntryPanelInstall();
            RoomListEntryPanelInstall();
            StartGameButtonInstall();
            CanvasModelInstall();
        }

        private void LoginPanelInstall()
        {
            Container
                .Bind<ILoginPanel>()
                .To<LoginPanel>()
                .AsSingle()
                .WithArguments(_loginPanel);
        }

        private void CreateOrJoinRoomPanelInstall()
        {
            Container
                .Bind<ICreateOrJoinRoomPanel>()
                .To<CreateOrJoinRoomPanel>()
                .AsSingle()
                .WithArguments(_createOrJoinRoomPanel);
        }

        private void InsideRoomPanelInstall()
        {
            Container
                .Bind<IInsideRoomPanel>()
                .To<InsideRoomPanel>()
                .AsSingle()
                .WithArguments(_insideRoomPanel);
        }

        private void PlayerListEntryPanelInstall()
        {
            Container
                .Bind<IPlayerListEntryPanel>()
                .To<PlayerListEntryPanel>()
                .AsSingle()
                .WithArguments(_playerListEntryPanel);
        }

        private void RoomListEntryPanelInstall()
        {
            Container
                .Bind<IRoomListEntryPanel>()
                .To<RoomListEntryPanel>()
                .AsSingle()
                .WithArguments(_roomListEntryPanel, _roomListEntryParent);
        }

        private void StartGameButtonInstall()
        {
            Container
                .Bind<IButton>()
                .To<StartGameButton>()
                .AsSingle()
                .WithArguments(_startGameButton);
        }

        private void CanvasModelInstall()
        {
            Container
                .Bind<ICanvasModel>()
                .To<CanvasModel>()
                .AsSingle();
        }
    }
}