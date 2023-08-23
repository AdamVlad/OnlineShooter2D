using Assets.Scripts.Model.Canvas.Interfaces;

using UnityEngine;

namespace Assets.Scripts.Model.Canvas
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