using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScriptsFinaux.Player
{
    public class InputManager : MonoBehaviour
    {
        public static event Action<bool> OnInputDeviceChanged;
        public static event Action<PlayerController> OnPlayer1Spawn;
        public static event Action<PlayerController> OnPlayer2Spawn;
    
        [SerializeField] private GameObject _UiScriptManager;
        [SerializeField] private GameObject _Player;

        private PlayerInput _playerInput;
        private PlayerController _playerController;
        private Pause _pause;
        private bool _isControllerConnected;
    

        private void Awake() {
            _playerInput = _Player.GetComponent<PlayerInput>();
            _playerController = _Player.GetComponent<PlayerController>();
            _pause = _UiScriptManager.GetComponent<Pause>();
            if (_playerInput == null) throw new NullReferenceException("PlayerInputManager is null");
        }

        private void Start() {
            if (_playerInput.playerIndex == 0) OnPlayer1Spawn?.Invoke(_playerController);
            if (_playerInput.playerIndex == 1) OnPlayer2Spawn?.Invoke(_playerController);
        
        }
    
        private void OnEnable()
        {
            InputSystem.onDeviceChange += OnDeviceChange;

            // Bind input actions
            _playerInput.actions["Move"].performed += OnMove;
            _playerInput.actions["Move"].canceled += OnMove;
        
            _playerInput.actions["Jump"].performed += OnJump;
            _playerInput.actions["Jump"].canceled += OnJump;
        
            _playerInput.actions["Shield"].performed += OnGuard;
            _playerInput.actions["Shield"].canceled += OnGuard;
        
            _playerInput.actions["Dash"].started += OnDash;
            _playerInput.actions["Dash"].canceled += OnDash;
        
            _playerInput.actions["Jetpack"].started += OnJetpack;
            _playerInput.actions["Jetpack"].canceled += OnJetpack;
        
            _playerInput.actions["Pause"].started += OnPauseMenuOpened;
            _playerInput.actions["Pause"].canceled += OnPauseMenuOpened;
        
            _playerInput.actions["DeactivateBomb"].performed += OnDeactivateBomb;
            _playerInput.actions["DeactivateBomb"].canceled += OnDeactivateBomb;
        
            DetectCurrentInputDevice();
        }

        private void OnDisable()
        {
            InputSystem.onDeviceChange -= OnDeviceChange;

            // Unbind input actions
            _playerInput.actions["Move"].performed -= OnMove;
            _playerInput.actions["Move"].canceled -= OnMove;
        
            _playerInput.actions["Jump"].performed -= OnJump;
            _playerInput.actions["Jump"].canceled -= OnJump;
        
            _playerInput.actions["Shield"].performed -= OnGuard;
            _playerInput.actions["Shield"].canceled -= OnGuard;
        
            _playerInput.actions["Dash"].started -= OnDash;
            _playerInput.actions["Dash"].canceled -= OnDash;
        
            _playerInput.actions["Jetpack"].started -= OnJetpack;
            _playerInput.actions["Jetpack"].canceled -= OnJetpack;
        
            _playerInput.actions["Pause"].started -= OnPauseMenuOpened;
            _playerInput.actions["Pause"].canceled -= OnPauseMenuOpened;
        
            _playerInput.actions["DeactivateBomb"].performed -= OnDeactivateBomb;
            _playerInput.actions["DeactivateBomb"].canceled -= OnDeactivateBomb;
        }
    
        private void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            if (change == InputDeviceChange.Added || change == InputDeviceChange.Removed)
            {
                DetectCurrentInputDevice();
            }
        }

        private void DetectCurrentInputDevice()
        {
            _isControllerConnected = Gamepad.all.Count > 0;
            OnInputDeviceChanged?.Invoke(_isControllerConnected);
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            if (_playerController.CanWalk)
            {
                _playerController.Walk = true;
            }
            _playerController.Move = context.ReadValue<Vector2>();
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            _playerController.Jump = context.ReadValueAsButton();
        }

        private void OnGuard(InputAction.CallbackContext context)
        {
            _playerController.UseShield = context.ReadValueAsButton();
        }

        private void OnDash(InputAction.CallbackContext context)
        {
            _playerController.UseDash = context.ReadValueAsButton();
        }

        private void OnJetpack(InputAction.CallbackContext context)
        {
            _playerController.UseJetpack = context.ReadValueAsButton();
        }

        private void OnPauseMenuOpened(InputAction.CallbackContext context)
        {
            _pause.PauseGame();
        }

        private void OnDeactivateBomb(InputAction.CallbackContext context)
        {
            _playerController.BombDeactivated = true;
        }
    }
}