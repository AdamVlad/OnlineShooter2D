using Assets.Scripts.LobbyScene.Model.Network.Interfaces;

namespace Assets.Scripts.LobbyScene.Model.Network
{
    internal class NetworkPlayerInfo : INetworkPlayerInfo
    {
        public string Name { get; set; }
        public const string PlayerLoadedLevel = "PlayerLoadedLevel";
    }
}