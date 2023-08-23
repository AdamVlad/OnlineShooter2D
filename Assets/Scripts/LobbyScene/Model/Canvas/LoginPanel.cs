using Assets.Scripts.LobbyScene.Model.Canvas.Interfaces;
using UnityEngine;

namespace Assets.Scripts.LobbyScene.Model.Canvas
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