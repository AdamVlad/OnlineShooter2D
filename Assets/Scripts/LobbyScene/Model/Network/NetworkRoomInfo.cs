using Assets.Scripts.LobbyScene.Model.Network.Interfaces;

namespace Assets.Scripts.LobbyScene.Model.Network
{
    internal class NetworkRoomInfo : INetworkRoomInfo
    {
        public string CreatedRoomName { get; set; }
        public string JoinedRoomName { get; set; }
    }
}