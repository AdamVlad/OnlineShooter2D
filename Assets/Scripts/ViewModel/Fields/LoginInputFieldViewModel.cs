using Assets.Scripts.Model.Network.Interfaces;
using Assets.Scripts.ViewModel.Base;

using UnityWeld.Binding;
using Zenject;

namespace Assets.Scripts.ViewModel.Fields
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