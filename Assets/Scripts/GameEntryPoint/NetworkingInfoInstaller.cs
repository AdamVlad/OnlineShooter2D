using Assets.Scripts.Model.Network;
using Assets.Scripts.Model.Network.Interfaces;

using Zenject;

namespace Assets.Scripts.GameEntryPoint
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
