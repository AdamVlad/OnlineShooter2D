using Assets.Scripts.Model.Network.Interfaces;

namespace Assets.Scripts.Model.Network
{
    internal class NetworkRoomInfo : INetworkRoomInfo
    {
        public string CreatedRoomName { get; set; }
        public string JoinedRoomName { get; set; }
    }
}