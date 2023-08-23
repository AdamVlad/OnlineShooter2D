using UnityEngine.UI;

namespace Assets.Scripts.LobbyScene.Model.Canvas.Interfaces
{
    internal interface IButton
    {
        Button Button{ get; }

        void SetActive(bool value);
    }
}