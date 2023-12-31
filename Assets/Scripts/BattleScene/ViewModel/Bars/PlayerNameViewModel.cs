using Assets.Scripts.BattleScene.ViewModel.Bars.Interfaces;
using Assets.Scripts.LobbyScene.ViewModel.Base;
using UnityWeld.Binding;

namespace Assets.Scripts.BattleScene.ViewModel.Bars
{
    [Binding]
    internal class PlayerNameViewModel : PropertyViewModelBase, IPlayerNameViewModel
    {
        private string _name;

        [Binding]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}