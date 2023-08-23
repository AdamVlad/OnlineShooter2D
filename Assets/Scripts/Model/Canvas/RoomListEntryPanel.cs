using Assets.Scripts.Model.Canvas.Interfaces;

using UnityEngine;

namespace Assets.Scripts.Model.Canvas
{
    internal class RoomListEntryPanel : IRoomListEntryPanel
    {
        public RoomListEntryPanel(
            GameObject panel,
            GameObject parent)
        {
            Panel = panel;
            Parent = parent;
        }

        public GameObject Panel { get; }
        public GameObject Parent { get; }
    }
}