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
        _playerInput.actions["Interact"].canceled += OnShielding;
    }

    private void OnDisable()
    {
        _playerInput.actions["Move"].performed -= OnMove;
        _playerInput.actions["Move"].canceled -= OnMove;
        
        _playerInput.actions["Interact"].performed -= OnShielding;
        _playerInput.actions["Interact"].canceled -= OnShielding;
    }
    
    void OnMove(InputAction.CallbackContext context)
    {
        _playerController.Move = context.ReadValue<Vector2>();
    }

    void OnShielding(InputAction.CallbackContext context)
    {
        Debug.Log("Shielding");
        _playerController._shieldOn = true;
    }
}
