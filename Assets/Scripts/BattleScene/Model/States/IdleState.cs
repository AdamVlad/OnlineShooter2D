using Assets.Scripts.BattleScene.Model.Input;
using Assets.Scripts.BattleScene.Model.Settings;
using Assets.Scripts.BattleScene.Model.States.Base;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.States
{
    internal class IdleState : StateBase
    {
        public IdleState(
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

        public override void Enter()
        {
            _rigidBody.velocity = Vector2.zero;

            _animator.SetFloat(_playerSettings.InputAxisX, 0);
            _animator.SetFloat(_playerSettings.InputAxisY, 0);
            _animator.SetFloat(_playerSettings.Velocity, 0);
            _animator.SetFloat(_playerSettings.InputAxisXHatch, _playerInput.InputAxis.x);
            _animator.SetFloat(_playerSettings.InputAxisYHatch, _playerInput.InputAxis.y);
        }

        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidBody;
        private readonly IPlayerInput _playerInput;
        private readonly IPlayerSettings _playerSettings;
    }
}