using UnityEngine.UI;

namespace Assets.Scripts.Model.Canvas.Interfaces
{
    internal interface IButton
    {
        Button Button{ get; }

        void SetActive(bool value);
    }
}