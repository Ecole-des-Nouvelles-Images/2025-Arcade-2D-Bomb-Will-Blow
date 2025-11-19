using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerController _playerController;
    private bool _isControllerConnected;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        _playerInput.actions["Move"].performed += OnMove;
        _playerInput.actions["Move"].canceled += OnMove;
        
        _playerInput.actions["Interact"].performed += OnShielding;


        _playerInput.actions["Attack"].performed += OnJetpackUse;
        _playerInput.actions["Attack"].canceled += OnJetpackUse;
    }

    private void OnDisable()
    {
        _playerInput.actions["Move"].performed -= OnMove;
        _playerInput.actions["Move"].canceled -= OnMove;
        
        _playerInput.actions["Interact"].performed -= OnShielding;
        
        _playerInput.actions["Attack"].performed -= OnJetpackUse;
        _playerInput.actions["Attack"].canceled -= OnJetpackUse;
    }
    
    void OnMove(InputAction.CallbackContext context)
    {
        _playerController.Move = context.ReadValue<Vector2>();
    }

    void OnShielding(InputAction.CallbackContext context)
    {
        Debug.Log("Shielding");
        _playerController.ShieldOn = true;
    }

    void OnJetpackUse(InputAction.CallbackContext context)
    {
        if (_playerController.JetpackFuel >= 3 && !_playerController.IsInJetpack)
        {
            Debug.Log("Jetpack used");
            _playerController.IsInJetpack = true;   
        }

        if (_playerController.JetpackFuel <= 4.8 && _playerController.IsInJetpack)
        {
            Debug.Log("Jetpack stopped");
            _playerController.IsInJetpack = false;
        }
        else
        {
            Debug.Log("Not enough fuel");
        }
    }
}
