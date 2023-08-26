using UnityEngine;

namespace Assets.Scripts.BattleScene.Extensions
{
    internal static class ComponentExtensions
    {
        public static T TryGetComponentOrThrowException<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject.TryGetComponent<T>(out var component))
            {
                throw new MissingComponentException($"Component {typeof(T)} not set on the game object with name {gameObject.name}");
            }

            return component;
        }

        public static T TryGetComponentInChildrenOrThrowException<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponentInChildren<T>() ??
                   throw new MissingComponentException(
                       $"Component {typeof(T)} not set on the children component from game object with name {gameObject.name}");
        }

        public static T TryGetComponentWithoutException<T>(this GameObject gameObject) where T : Component
        {
            return !gameObject.TryGetComponent<T>(out var component) ? null : component;
        }
    }
}
