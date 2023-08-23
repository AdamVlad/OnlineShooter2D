﻿using Assets.Scripts.Model.Network.Interfaces;
using Assets.Scripts.ViewModel.Base;

using UnityWeld.Binding;
using Zenject;

namespace Assets.Scripts.ViewModel.Fields
{
    [Binding]
    internal class CreatedRoomInputFieldViewModel : PropertyViewModelBase
    {
        [Inject] private readonly INetworkRoomInfo _networkRoomInfo;

        private string _text;

        [Binding]
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                _networkRoomInfo.CreatedRoomName = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}