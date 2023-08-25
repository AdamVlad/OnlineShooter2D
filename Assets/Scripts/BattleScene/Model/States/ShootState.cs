using Assets.Scripts.BattleScene.Model.Input;
using Assets.Scripts.BattleScene.Model.Settings;
using Assets.Scripts.BattleScene.Model.States.Base;
using Assets.Scripts.BattleScene.Model.States.Interfaces;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.States
{
    internal class ShootState : StateBase
    {
        public ShootState(
            Animator animator,
            IPlayerInput playerInput,
            IPlayerSettings playerSettings,
            IStateMachine stateMachine)
        {
            _animator = animator;
            _playerInput = playerInput;
            _playerSettings = playerSettings;
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            _shootDelay = _playerSettings.ShootDelay;

            _animator.SetTrigger(_playerSettings.ShootTrigger);
            _animator.SetFloat(_playerSettings.InputAxisX, 0);
            _animator.SetFloat(_playerSettings.InputAxisY, 0);
            _animator.SetFloat(_playerSettings.Velocity, 0);
            _animator.SetFloat(_playerSettings.InputAxisXHatch, _playerInput.InputAxis.x);
            _animator.SetFloat(_playerSettings.InputAxisYHatch, _playerInput.InputAxis.y);
        }

        public override void Update()
        {
            _shootDelay -= Time.deltaTime;
            if (_shootDelay <= 0)
            {
                _stateMachine.ChangeState(_stateMachine.PreviousState);
            }
        }

        public override void Exit()
        {
            _shootDelay = _playerSettings.ShootDelay;
        }

        private float _shootDelay;

        private readonly Animator _animator;
        private readonly IPlayerInput _playerInput;
        private readonly IPlayerSettings _playerSettings;
        private readonly IStateMachine _stateMachine;
    }
}