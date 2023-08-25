using System;
using Assets.Scripts.LobbyScene.ViewModel.Base;
using UnityWeld.Binding;

namespace Assets.Scripts.BattleScene.ViewModel
{
    [Binding]
    internal class HpBarViewModel : PropertyViewModelBase
    {
        private Single _fill;

        [Binding]
        public Single Fill
        {
            get => _fill;
            set
            {
                _fill = value;
                OnPropertyChanged(nameof(Fill));
            }
        }
    }
}