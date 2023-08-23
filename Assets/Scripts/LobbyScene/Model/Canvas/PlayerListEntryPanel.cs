using Assets.Scripts.LobbyScene.Model.Canvas.Interfaces;
using UnityEngine;

namespace Assets.Scripts.LobbyScene.Model.Canvas
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