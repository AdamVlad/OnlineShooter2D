using System.ComponentModel;
using System.Runtime.CompilerServices;

using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.ViewModel.Base
{
    internal abstract class PropertyViewModelBase : MonoBehaviour, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}