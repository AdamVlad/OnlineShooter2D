namespace Assets.Scripts.Model.Network.Interfaces
{
    internal interface INetworkRoomInfo
    {
        string CreatedRoomName { get; set; }
        string JoinedRoomName { get; set; }
    }
}