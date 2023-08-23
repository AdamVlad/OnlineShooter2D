using UnityEngine;

namespace Assets.Scripts.LobbyScene.Model.Canvas.Interfaces
{
    internal interface IRoomListEntryPanel : IPanel
    {
        GameObject Parent { get; }
    }
}