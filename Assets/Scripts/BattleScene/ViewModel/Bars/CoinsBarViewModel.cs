using System;
using Assets.Scripts.BattleScene.ViewModel.Bars.Interfaces;
using Assets.Scripts.LobbyScene.ViewModel.Base;
using UnityWeld.Binding;

namespace Assets.Scripts.BattleScene.ViewModel.Bars
{
    [Binding]
    internal class CoinsBarViewModel : PropertyViewModelBase, ICoinsViewModel
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