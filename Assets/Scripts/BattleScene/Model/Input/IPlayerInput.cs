using System;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.Input
{
    internal interface IPlayerInput
    {
        event Action PlayerStartedMoving;
        event Action PlayerStopped;

        Vector2 InputAxis { get; }

        void Initialize();
        void Enable();
        void Disable();
    }
}