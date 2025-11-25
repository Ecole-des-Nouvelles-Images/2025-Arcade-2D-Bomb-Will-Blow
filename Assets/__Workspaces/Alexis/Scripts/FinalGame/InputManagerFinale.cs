using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerFinale : MonoBehaviour
{
    public static event Action<bool> OnInputDeviceChanged;

    private PlayerInput _playerInput;
    private PlayerControllerFinal _playerControllerFinal;
    private bool _isControllerConnected;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControllerFinal = GetComponent<PlayerControllerFinal>();
        if (_playerInput == null) throw new NullReferenceException("PlayerInputManager is null");
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
}
