using Assets.Scripts.Model.Network.Interfaces;

namespace Assets.Scripts.Model.Network
{
    internal class NetworkPlayerInfo : INetworkPlayerInfo
    {
        public string Name { get; set; }
        public const string PlayerLoadedLevel = "PlayerLoadedLevel";
    }
}