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
            Transform transform,
            IPlayerInput playerInput,
            IPlayerSettings playerSettings)
        {
            _animator = animator;
            _transform = transform;
            _playerInput = playerInput;
            _playerSettings = playerSettings;
        }

        public override void FixedUpdate()
        {
            _transform.position += new Vector3(
                _playerInput.InputAxis.x * _playerSettings.WalkSpeed,
                _playerInput.InputAxis.y * _playerSettings.WalkSpeed,
                0);

            var velocity = Mathf.Sqrt(
                Mathf.Pow(_playerInput.InputAxis.x, 2) + 
                Mathf.Pow(_playerInput.InputAxis.y, 2)); 

            _animator.SetFloat(_playerSettings.Velocity, velocity);
            _animator.SetFloat(_playerSettings.InputAxisX, _playerInput.InputAxis.x);
            _animator.SetFloat(_playerSettings.InputAxisY, _playerInput.InputAxis.y);
        }

        private readonly Animator _animator;
        private readonly Transform _transform;
        private readonly IPlayerInput _playerInput;
        private readonly IPlayerSettings _playerSettings;
    }
}