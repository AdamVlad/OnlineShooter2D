using Assets.Scripts.BattleScene.Model.Input;
using Assets.Scripts.BattleScene.Model.Settings;
using Assets.Scripts.BattleScene.Model.States.Base;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.States
{
    internal class WalkState : StateBase
    {
        public WalkState(
            Animator animator,
            Rigidbody2D rigidbody,
            IPlayerInput playerInput,
            IPlayerSettings playerSettings)
        {
            _animator = animator;
            _rigidBody = rigidbody;
            _playerInput = playerInput;
            _playerSettings = playerSettings;
        }

        public override void FixedUpdate()
        {
            _rigidBody.velocity = _playerInput.InputAxis * _playerSettings.WalkSpeed;
            _animator.SetFloat(_playerSettings.Velocity, Mathf.Abs(_rigidBody.velocity.magnitude));
            _animator.SetFloat(_playerSettings.InputAxisX, _playerInput.InputAxis.x);
            _animator.SetFloat(_playerSettings.InputAxisY, _playerInput.InputAxis.y);
        }

        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidBody;
        private readonly IPlayerInput _playerInput;
        private readonly IPlayerSettings _playerSettings;
    }
}