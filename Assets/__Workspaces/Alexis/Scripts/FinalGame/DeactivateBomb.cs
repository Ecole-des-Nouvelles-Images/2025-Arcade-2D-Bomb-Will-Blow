using System;
using UnityEngine;

public class DeactivateBomb : MonoBehaviour
{
    private GameObject _p1;
    private GameObject _p2;
    
    private PlayerControllerFinal _playerControllerP1;
    private PlayerControllerFinal _playerControllerP2;
    
    private bool _playerControllerP1Found;
    private bool _playerControllerP2Found;

    private void Awake() {
        InputManagerFinale.OnPlayer1Spawn += Player1Spawn;
        InputManagerFinale.OnPlayer2Spawn += InputManagerFinaleOnOnPlayer2Spawn;
    }

    private void OnDestroy() {
        InputManagerFinale.OnPlayer1Spawn -= Player1Spawn;
        InputManagerFinale.OnPlayer2Spawn -= InputManagerFinaleOnOnPlayer2Spawn;
    }

    private void InputManagerFinaleOnOnPlayer2Spawn(PlayerControllerFinal playerControllerFinal) {
        _playerControllerP2 = playerControllerFinal;
    }

    private void Player1Spawn(PlayerControllerFinal playerControllerFinal) {
        _playerControllerP1 = playerControllerFinal;
    }
    // Update is called once per frame
    void Update()
    { 
        /*if (!_playerControllerP1Found)
        {
            _p1 = GameObject.FindGameObjectWithTag("Player");
            _playerControllerP1 =  _p1.GetComponent<PlayerControllerFinal>();
            if (_playerControllerP1 == _playerControllerP1.GetComponent<PlayerControllerFinal>())
            {
                _playerControllerP1Found = true;
            }
        }

        if (!_playerControllerP2Found)
        {
            _p2 = GameObject.FindGameObjectWithTag("Player2");
            if (_p2 == null) return;
            _playerControllerP2 = _p2.GetComponent<PlayerControllerFinal>();
            if (_playerControllerP2 == _playerControllerP2.GetComponent<PlayerControllerFinal>())
            {
                _playerControllerP2Found = true; 
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerControllerP1.CanDeactivateBomb = true;
        }

        if (other.gameObject.tag == "Player2")
        {
            _playerControllerP2.CanDeactivateBomb  = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerControllerP1.CanDeactivateBomb  = false;
        }

        if (other.gameObject.tag == "Player2")
        {
            _playerControllerP2.CanDeactivateBomb   = false;
        }
    }
}
