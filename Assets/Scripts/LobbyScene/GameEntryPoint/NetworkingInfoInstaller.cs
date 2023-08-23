using Assets.Scripts.LobbyScene.Model.Network;
using Assets.Scripts.LobbyScene.Model.Network.Interfaces;
using Zenject;

namespace Assets.Scripts.LobbyScene.GameEntryPoint
{
    internal sealed class NetworkingInfoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            NetworkPlayerInfoInstall();
            NetworkRoomInfoInstall();
        }

        private void NetworkPlayerInfoInstall()
        {
            Container
                .Bind<INetworkPlayerInfo>()
                .To<NetworkPlayerInfo>()
                .AsSingle();
        }

        private void NetworkRoomInfoInstall()
        {
            Container
                .Bind<INetworkRoomInfo>()
                .To<NetworkRoomInfo>()
                .AsSingle();
        }
    }
}
