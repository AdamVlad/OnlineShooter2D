using Assets.Scripts.LobbyScene.Model.Network.Interfaces;
using Assets.Scripts.LobbyScene.ViewModel.Base;
using UnityWeld.Binding;
using Zenject;

namespace Assets.Scripts.LobbyScene.ViewModel.Fields
{
    [Binding]
    internal class LoginInputFieldViewModel : PropertyViewModelBase
    {
        [Inject] private readonly INetworkPlayerInfo _networkPlayerInfo;

        private string _text;

        [Binding]
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                _networkPlayerInfo.Name = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}