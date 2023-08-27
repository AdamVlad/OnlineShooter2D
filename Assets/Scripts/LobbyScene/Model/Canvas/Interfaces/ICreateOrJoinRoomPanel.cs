namespace Assets.Scripts.LobbyScene.Model.Canvas.Interfaces
{
    internal interface ICreateOrJoinRoomPanel : IPanel
    {
        string ConnectionToRoomStatus { get; set; }
    }
}