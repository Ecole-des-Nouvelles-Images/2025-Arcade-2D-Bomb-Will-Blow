using System;
using System.Net;
using ScriptsFinaux;
using ScriptsFinaux.Player;
using UnityEngine;

public class ActivateVictoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _victoryUI;

    public bool P1Win;
    public bool P2Win;
    
    private GameObject _p1;
    private GameObject _p2;
    
    private PlayerController  _playerControllerP1;
    private PlayerController  _playerControllerP2;
    
    private bool _playerControllerP1Found;
    private bool _playerControllerP2Found;

    private void Awake() {
        InputManager.OnPlayer1Spawn += Player1Spawn;
        InputManager.OnPlayer2Spawn += InputManagerFinaleOnOnPlayer2Spawn;
    }

    private void OnDestroy() {
        InputManager.OnPlayer1Spawn -= Player1Spawn;
        InputManager.OnPlayer2Spawn -= InputManagerFinaleOnOnPlayer2Spawn;
    }

    private void InputManagerFinaleOnOnPlayer2Spawn(PlayerController playerController) {
        _playerControllerP2 = playerController;
    }

    private void Player1Spawn(PlayerController playerController) {
        _playerControllerP1 = playerController;
    }

    // Update is called once per frame
    void Update()
    {
        //ActivateVictoryScenes
        if (_playerControllerP1.PlayerData.P1Win)
        {
            Debug.Log("Player 1 deactivated bomb");
            P1Win = true;
            _victoryUI.SetActive(true);
            _playerControllerP2.PlayerData.P1Win = false;
            Time.timeScale = 0;
        }

        // if (_playerControllerP2 == null) return;
        
        if (_playerControllerP2.PlayerData.P2Win)
        {
            Debug.Log("Player 2 deactivated bomb");
            P2Win = true;
            _victoryUI.SetActive(true);
            _playerControllerP2.PlayerData.P2Win = false;
            Time.timeScale = 0;
        }
    }
}
