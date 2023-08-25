using Assets.Scripts.BattleScene.Extensions;
using Assets.Scripts.BattleScene.Model.Input;
using Assets.Scripts.BattleScene.Model.Settings;
using Assets.Scripts.BattleScene.Model.States;
using Assets.Scripts.BattleScene.Model.States.Base;
using Assets.Scripts.BattleScene.Model.States.Interfaces;

using Photon.Pun;
using UnityEngine;

namespace Assets.Scripts.BattleScene.ViewModel
{
    [RequireComponent(
        typeof(CapsuleCollider2D),
        typeof(Rigidbody2D),
        typeof(PhotonView))]
    internal class PlayerViewModel : MonoBehaviour
    {
        [SerializeField] private PlayerSettings _playerSettings;

        private PhotonView _photonView;

        private IPlayerInput _playerInput;
        private IStateMachine _stateMachine;
        private StateBase _idleState;
        private StateBase _walkState;
        private StateBase _shootState;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            if (!_photonView.AmOwner) return;

            InitializeInput();
            InitializeStates();
        }

        private void OnEnable()
        {
            if (!_photonView.AmOwner) return;

            _playerInput.PlayerShot += OnPlayerShot;
            _playerInput.PlayerStartedMoving += OnPlayerStartedMoving;
            _playerInput.PlayerStopped += OnPlayerStopped;

            _playerInput.Enable();
        }

        private void OnDisable()
        {
            if (!_photonView.AmOwner) return;

            _playerInput.PlayerShot -= OnPlayerShot;
            _playerInput.PlayerStartedMoving -= OnPlayerStartedMoving;
            _playerInput.PlayerStopped -= OnPlayerStopped;

            _playerInput.Disable();
        }

        private void Update()
        {
            _stateMachine?.CurrentState.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine?.CurrentState.FixedUpdate();
        }

        private void OnPlayerShot()
        {
            _stateMachine?.ChangeState(_shootState);
        }

        private void OnPlayerStartedMoving()
        {
            _stateMachine?.ChangeState(_walkState);
        }

        private void OnPlayerStopped()
        {
            _stateMachine?.ChangeState(_idleState);
        }

        [PunRPC]
        private void Shoot(Vector3 position, Vector2 direction)
        {
            var shiftedPosition = new Vector3(position.x, position.y + 0.7f, position.z);
            var bullet = Instantiate(_playerSettings.Bullet, shiftedPosition, Quaternion.identity);
            bullet.Initialize(direction, _photonView.Owner);
        }

        #region Initialize

        private void InitializeInput()
        {
            _playerInput = new PlayerInput(new PlayerControls());
            _playerInput.Initialize();
        }

        private void InitializeStates()
        {
            var animator = gameObject.TryGetComponentInChildrenOrThrowException<Animator>();

            _stateMachine = new StateMachine();

            _idleState = new IdleState(animator, _playerInput, _playerSettings);
            _walkState = new WalkState(animator, gameObject.transform, _playerInput, _playerSettings);
            _shootState = new ShootState(animator, gameObject.transform, _photonView, _playerInput, _playerSettings, _stateMachine);

            _stateMachine.Initialize(_idleState);
        }

        #endregion
    }
}