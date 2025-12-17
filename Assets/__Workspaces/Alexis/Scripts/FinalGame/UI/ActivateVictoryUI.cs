using System;
using System.Net;
using UnityEngine;

public class ActivateVictoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _victoryUI;

    public bool P1Win;
    public bool P2Win;
    
    private GameObject _p1;
    private GameObject _p2;
    
    private PlayerControllerFinal  _playerControllerP1;
    private PlayerControllerFinal  _playerControllerP2;
    
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
        //ActivateVictoryScenes
        if (_playerControllerP1.CanDeactivateBomb && _playerControllerP1.BombDeactivated)
        {
            P1Win = true;
            _victoryUI.SetActive(true);
        }

        if (_playerControllerP2 == null) return;
        
        if (_playerControllerP2.CanDeactivateBomb && _playerControllerP2.BombDeactivated)
        {
            P2Win = true;
            _victoryUI.SetActive(true);
        }
    }
}
