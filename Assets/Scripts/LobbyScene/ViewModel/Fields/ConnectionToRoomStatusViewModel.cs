using Assets.Scripts.LobbyScene.ViewModel.Base;
using Assets.Scripts.LobbyScene.ViewModel.Fields.Interfaces;
using UnityWeld.Binding;

namespace Assets.Scripts.LobbyScene.ViewModel.Fields
{
    [Binding]
    internal class ConnectionToRoomStatusViewModel : PropertyViewModelBase, IConnectionToRoomStatusViewModel
    {
        private string _text;

        [Binding]
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}