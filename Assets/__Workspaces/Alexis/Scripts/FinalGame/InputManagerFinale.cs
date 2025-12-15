using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerFinale : MonoBehaviour
{
    public static event Action<bool> OnInputDeviceChanged;
    public static event Action<PlayerControllerFinal> OnPlayer1Spawn;
    public static event Action<PlayerControllerFinal> OnPlayer2Spawn;
    
    [SerializeField] private GameObject _UiScriptManager;

    private PlayerInput _playerInput;
    private PlayerControllerFinal _playerControllerFinal;
    private InGamePause _inGamePause;
    private bool _isControllerConnected;
    

    private void Awake() {
        _playerInput = GetComponent<PlayerInput>();
        _playerControllerFinal = GetComponent<PlayerControllerFinal>();
        _inGamePause = _UiScriptManager.GetComponent<InGamePause>();
        if (_playerInput == null) throw new NullReferenceException("PlayerInputManager is null");
        
        Debug.Log(" playde ID is "+ _playerInput.playerIndex);
    }

    private void Start() {
        if (_playerInput.playerIndex == 0) OnPlayer1Spawn?.Invoke(_playerControllerFinal);
        if (_playerInput.playerIndex == 1) OnPlayer2Spawn?.Invoke(_playerControllerFinal);
        
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

        Debug.Log(_isControllerConnected
            ? "Controller connected: Switching to Gamepad controls."
            : "No controller connected: Switching to Keyboard/Mouse controls.");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (_playerControllerFinal.CanWalk)
        {
            _playerControllerFinal.Walk = true;
        }
        _playerControllerFinal.Move = context.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _playerControllerFinal.Jump = context.ReadValueAsButton();
    }

    private void OnGuard(InputAction.CallbackContext context)
    {
        _playerControllerFinal.UseShield = context.ReadValueAsButton();
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        _playerControllerFinal.UseDash = context.ReadValueAsButton();
    }

    private void OnJetpack(InputAction.CallbackContext context)
    {
        _playerControllerFinal.UseJetpack = context.ReadValueAsButton();
    }

    private void OnPauseMenuOpened(InputAction.CallbackContext context)
    {
        _inGamePause.OpenPauseMenu();
    }

    private void OnDeactivateBomb(InputAction.CallbackContext context)
    {
        _playerControllerFinal.BombDeactivated =  true;
    }
}
