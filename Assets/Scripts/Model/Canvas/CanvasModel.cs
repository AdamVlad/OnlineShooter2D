using Assets.Scripts.Model.Canvas.Interfaces;

namespace Assets.Scripts.Model.Canvas
{
    internal sealed class CanvasModel : ICanvasModel
    {
        public CanvasModel(
            ILoginPanel loginPanel,
            ICreateOrJoinRoomPanel createOrJoinRoomPanel,
            IInsideRoomPanel insideRoomPanel,
            IPlayerListEntryPanel playerListEntryPanel,
            IRoomListEntryPanel roomListEntryPanel,
            IButton startGameButton)
        {
            LoginPanel = loginPanel;
            CreateOrJoinRoomPanel = createOrJoinRoomPanel;
            InsideRoomPanel = insideRoomPanel;
            PlayerListEntryPanel = playerListEntryPanel;
            RoomListEntryPanel = roomListEntryPanel;
            StartGameButton = startGameButton;
        }

        public ILoginPanel LoginPanel { get; }
        public ICreateOrJoinRoomPanel CreateOrJoinRoomPanel { get; }
        public IInsideRoomPanel InsideRoomPanel { get; }
        public IPlayerListEntryPanel PlayerListEntryPanel { get; }
        public IRoomListEntryPanel RoomListEntryPanel { get; }
        public IButton StartGameButton { get; }


        public void SetActivePanel(string activePanel)
        {
            LoginPanel.Panel.SetActive(activePanel.Equals(LoginPanel.Panel.name));
            CreateOrJoinRoomPanel.Panel.SetActive(activePanel.Equals(CreateOrJoinRoomPanel.Panel.name));
            InsideRoomPanel.Panel.SetActive(activePanel.Equals(InsideRoomPanel.Panel.name));
        }
    }
}