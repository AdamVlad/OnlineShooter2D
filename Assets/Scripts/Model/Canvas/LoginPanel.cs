using Assets.Scripts.Model.Canvas.Interfaces;

using UnityEngine;

namespace Assets.Scripts.Model.Canvas
{
    internal class LoginPanel : ILoginPanel
    {
        public LoginPanel(GameObject panel)
        {
            Panel = panel;
        }

        public GameObject Panel { get; }
    }
}