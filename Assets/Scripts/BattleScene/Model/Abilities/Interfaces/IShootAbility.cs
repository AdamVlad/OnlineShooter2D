using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.Abilities.Interfaces
{
    internal interface IShootAbility
    {
        void Shoot(Vector3 position, Vector2 direction);
    }
}