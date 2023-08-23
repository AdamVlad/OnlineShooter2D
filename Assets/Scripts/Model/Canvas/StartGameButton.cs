using Assets.Scripts.Model.Canvas.Interfaces;

using UnityEngine.UI;

namespace Assets.Scripts.Model.Canvas
{
    internal class StartGameButton : IButton
    {
        public StartGameButton(Button button)
        {
            Button = button;
        }

        public Button Button { get; }

        public void SetActive(bool value)
        {
            Button.gameObject.SetActive(value);
        }
    }
}