using Assets.Scripts.BattleScene.Extensions;
using Assets.Scripts.BattleScene.Model.Input;
using Assets.Scripts.BattleScene.Model.States;
using Assets.Scripts.BattleScene.Model.States.Base;
using UnityEngine;

namespace Assets.Scripts.BattleScene.ViewModel
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal class PlayerViewModel : MonoBehaviour
    {
        private void Awake()
        {
            _playerInput = new PlayerInput(new PlayerControls());

            var animator = gameObject.TryGetComponentInChildrenOrThrowException<Animator>();
            var rigidbody = gameObject.TryGetComponentOrThrowException<Rigidbody2D>();

            _stateMachine = new StateMachine();
            _idleState = new IdleState(animator, rigidbody);
            _walkState = new WalkState(animator, rigidbody, _playerInput);

            _stateMachine.Initialize(_idleState);
            _playerInput.Initialize();
        }

        private void OnEnable()
        {
            _playerInput.PlayerStartedMoving += OnPlayerStartedMoving;
            _playerInput.PlayerStopped += OnPlayerStopped;

            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.PlayerStartedMoving -= OnPlayerStartedMoving;
            _playerInput.PlayerStopped -= OnPlayerStopped;

            _playerInput.Disable();
        }

        private void Update()
        {
            _stateMachine.CurrentState.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.FixedUpdate();
        }

        private void OnPlayerStartedMoving()
        {
            _stateMachine.ChangeState(_walkState);
        }

        private void OnPlayerStopped()
        {
            _stateMachine.ChangeState(_idleState);
        }

        private IPlayerInput _playerInput;
        private IStateMachine _stateMachine;
        private StateBase _idleState;
        private StateBase _walkState;
    }
}