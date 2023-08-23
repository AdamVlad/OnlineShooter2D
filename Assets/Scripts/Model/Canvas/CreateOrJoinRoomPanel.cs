using Assets.Scripts.Model.Canvas.Interfaces;

using UnityEngine;

namespace Assets.Scripts.Model.Canvas
{
    internal class CreateOrJoinRoomPanel : ICreateOrJoinRoomPanel
    {
        public CreateOrJoinRoomPanel(GameObject panel)
        {
            Panel = panel;
        }

        public GameObject Panel { get; }
    }
}