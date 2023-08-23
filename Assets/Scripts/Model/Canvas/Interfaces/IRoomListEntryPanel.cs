using UnityEngine;

namespace Assets.Scripts.Model.Canvas.Interfaces
{
    internal interface IRoomListEntryPanel : IPanel
    {
        GameObject Parent { get; }
    }
}