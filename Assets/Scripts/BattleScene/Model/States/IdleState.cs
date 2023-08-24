using Assets.Scripts.BattleScene.Model.States.Base;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.States
{
    internal class IdleState : StateBase
    {
        public IdleState(
            Animator animator,
            Rigidbody2D rigidbody)
        {
            _animator = animator;
            _rigidBody = rigidbody;
        }

        public override void Enter()
        {
            _rigidBody.velocity = Vector2.zero;

            _animator.SetFloat("x", 0);
            _animator.SetFloat("y", 0);
        }

        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidBody;
    }
}