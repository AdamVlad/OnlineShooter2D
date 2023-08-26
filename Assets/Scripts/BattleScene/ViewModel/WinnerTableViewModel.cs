using Assets.Scripts.LobbyScene.ViewModel.Base;
using UnityWeld.Binding;

namespace Assets.Scripts.BattleScene.ViewModel
{
    [Binding]
    internal class WinnerTableViewModel : PropertyViewModelBase
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
