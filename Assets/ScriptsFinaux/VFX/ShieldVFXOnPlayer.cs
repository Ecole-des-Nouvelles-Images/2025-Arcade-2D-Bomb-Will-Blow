using System;
using ScriptsFinaux.Player;
using UnityEngine;

public class ShieldVFXOnPlayer : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerController _playerController;
    private Vector2 _positionToReach;
    private Vector2 _actualPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _actualPosition = transform.position;
    }

    private void Update()
    {
        _actualPosition = transform.position;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player2")
        {
            _playerController = other.gameObject.GetComponent<PlayerController>();
            // if (_positionToReach != null)
            // {
            //     _rb.AddForce(_actualPosition - _positionToReach, ForceMode2D.Impulse);
            // }
            _positionToReach = other.transform.position;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player2")
        {
            _playerController = other.gameObject.GetComponent<PlayerController>();
            _positionToReach = other.transform.position;
            if (other.transform.position.x > _actualPosition.x)
            {
                _rb.AddForce(new Vector2(10 * Mathf.Abs(_playerController.Move.x) * Mathf.Abs(_playerController.JumpXDynamic), 10 * _playerController.JumpY));
            }
            else if (other.transform.position.x < _actualPosition.x)
            {
                _rb.AddForce(new Vector2(- 10 * Mathf.Abs(_playerController.Move.x) * Mathf.Abs(_playerController.JumpXDynamic), 10 * _playerController.JumpY));
            }
            else
            {
                _rb.AddForce(new Vector2(0, - _playerController.PlayerData.SlideDownForce / 100 * Time.deltaTime));
            }
        }
    }
}