using Assets.Scripts.BattleScene.Extensions;
using Assets.Scripts.BattleScene.Model.Input;
using Assets.Scripts.BattleScene.Model.Settings;
using Assets.Scripts.BattleScene.Model.States;
using Assets.Scripts.BattleScene.Model.States.Base;
using Assets.Scripts.BattleScene.Model.States.Interfaces;

using Photon.Pun;
using System;
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

        private HpBarViewModel _hpBar;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            
            InitializeInput();
            InitializeStates();
            InitializeHpBar();
            InitializePlayerName();
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
            Debug.Log("Shoot");

            var shiftedPosition = new Vector3(position.x, position.y + 0.7f, position.z);
            var bullet = Instantiate(_playerSettings.Bullet, shiftedPosition, Quaternion.identity);
            bullet.Initialize(direction, _photonView.Owner);
        }

        [PunRPC]
        private void TakeDamage(float damage)
        {
            _hpBar.Fill -= (Single)(damage / 100);

            //if (_hpBar.CurrentHealth > 0) return;
        }

        #region Initialize

        private void InitializeInput()
        {
            if (!_photonView.AmOwner) return;

            _playerInput = new PlayerInput(new PlayerControls());
            _playerInput.Initialize();
        }

        private void InitializeStates()
        {
            if (!_photonView.AmOwner) return;

            var animator = gameObject.TryGetComponentInChildrenOrThrowException<Animator>();

            _stateMachine = new StateMachine();

            _idleState = new IdleState(animator, _playerInput, _playerSettings);
            _walkState = new WalkState(animator, gameObject.transform, _playerInput, _playerSettings);
            _shootState = new ShootState(animator, gameObject.transform, _photonView, _playerInput, _playerSettings, _stateMachine);

            _stateMachine.Initialize(_idleState);
        }

        private void InitializeHpBar()
        {
            var ownHpBar = gameObject.TryGetComponentInChildrenOrThrowException<HpBarViewModel>();

            if (!_photonView.AmOwner)
            {
                _hpBar = ownHpBar;
            }
            else
            {
                Destroy(ownHpBar.gameObject);
                ownHpBar.enabled = false;
                _hpBar = GameObject.Find("HudCanvas").GetComponent<HpBarViewModel>();
            }

            _hpBar.Fill = 1;
        }

        private void InitializePlayerName()
        {
            if (!_photonView.AmOwner)
            {
                var playerNameBar = gameObject.TryGetComponentInChildrenOrThrowException<PlayerNameViewModel>();
                playerNameBar.Name = _photonView.Owner.NickName;
            }
        }

        #endregion
    }
}