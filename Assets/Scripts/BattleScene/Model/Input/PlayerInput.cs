using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.BattleScene.Model.Input
{
    internal sealed class PlayerInput : IPlayerInput
    {
        public PlayerInput(PlayerControls controls)
        {
            _playerControls = controls;
        }

        public event Action PlayerShot;
        public event Action PlayerStartedMoving;
        public event Action PlayerStopped;
        public Vector2 InputAxis { get; private set; }

        public void Initialize()
        {
            _playerControls.InputActionMap.Move.started += OnStartedMoving;
            _playerControls.InputActionMap.Move.performed += OnMoved;
            _playerControls.InputActionMap.Move.canceled += OnStopped;

            _playerControls.InputActionMap.Shoot.started += OnShot;
        }

        public void Enable()
        {
            _playerControls.Enable();
        }

        public void Disable()
        {
            _playerControls.Disable();
        }

        private void OnShot(InputAction.CallbackContext callback)
        {
            OnPlayerShot();
        }

        private void OnStartedMoving(InputAction.CallbackContext callback)
        {
            OnPlayerStartedMoving();
        }

        private void OnStopped(InputAction.CallbackContext callback)
        {
            OnPlayerStopped();
        }

        private void OnMoved(InputAction.CallbackContext callback)
        {
            InputAxis = callback.ReadValue<Vector2>();
        }

        private void OnPlayerShot()
        {
            PlayerShot?.Invoke();
        }

        private void OnPlayerStartedMoving()
        {
            PlayerStartedMoving?.Invoke();
        }

        private void OnPlayerStopped()
        {
            PlayerStopped?.Invoke();
        }

        private readonly PlayerControls _playerControls;
    }
}