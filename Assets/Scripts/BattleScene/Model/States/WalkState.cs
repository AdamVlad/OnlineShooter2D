using Assets.Scripts.BattleScene.Model.Input;
using Assets.Scripts.BattleScene.Model.States.Base;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.States
{
    internal class WalkState : StateBase
    {
        public WalkState(
            Animator animator,
            Rigidbody2D rigidbody,
            IPlayerInput playerInput)
        {
            _animator = animator;
            _rigidBody = rigidbody;
            _playerInput = playerInput;
        }

        public override void FixedUpdate()
        {
            _rigidBody.velocity = _playerInput.InputAxis * 2;

            _animator.SetFloat("x", _playerInput.InputAxis.x);
            _animator.SetFloat("y", _playerInput.InputAxis.y);
        }

        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidBody;
        private readonly IPlayerInput _playerInput;
    }
}