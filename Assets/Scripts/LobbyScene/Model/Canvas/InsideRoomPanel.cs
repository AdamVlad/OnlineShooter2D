using Assets.Scripts.LobbyScene.Model.Canvas.Interfaces;
using UnityEngine;

namespace Assets.Scripts.LobbyScene.Model.Canvas
{
    internal class InsideRoomPanel : IInsideRoomPanel
    {
        public InsideRoomPanel(GameObject panel)
        {
            Panel = panel;
        }

        public GameObject Panel { get; }
    }
}