using Assets.Scripts.Model.Canvas.Interfaces;

using UnityEngine;

namespace Assets.Scripts.Model.Canvas
{
    internal class PlayerListEntryPanel : IPlayerListEntryPanel
    {
        public PlayerListEntryPanel(GameObject panel)
        {
            Panel = panel;
        }

        public GameObject Panel { get; }
    }
}