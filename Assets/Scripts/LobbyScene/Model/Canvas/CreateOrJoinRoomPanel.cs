using Assets.Scripts.LobbyScene.Model.Canvas.Interfaces;
using Assets.Scripts.LobbyScene.ViewModel.Fields.Interfaces;
using UnityEngine;

namespace Assets.Scripts.LobbyScene.Model.Canvas
{
    internal class CreateOrJoinRoomPanel : ICreateOrJoinRoomPanel
    {
        public CreateOrJoinRoomPanel(
            GameObject panel,
            IConnectionToRoomStatusViewModel viewModel)
        {
            Panel = panel;
            _viewModel = viewModel;
        }

        public GameObject Panel { get; }

        private string _connectionToRoomStatus;

        public string ConnectionToRoomStatus
        {
            get => _connectionToRoomStatus;
            set
            {
                _connectionToRoomStatus = value;
                _viewModel.Text = _connectionToRoomStatus;
            }
        }

        private IConnectionToRoomStatusViewModel _viewModel;
    }
}