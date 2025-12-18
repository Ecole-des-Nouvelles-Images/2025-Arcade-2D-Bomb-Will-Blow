using __Workspaces.Alexis.Scripts.FinalGame;
using __Workspaces.Alexis.Scripts.FinalGame.Player;
using UnityEngine;

public class VictoryAfterDeath : MonoBehaviour
{
    [SerializeField] private GameObject _victoryUI;
    
    private PlayerController  _playerControllerP1;
    private PlayerController  _playerControllerP2;

    private PlayerDamagedSystem _playerDamagedSystemP1;
    private PlayerDamagedSystem _playerDamagedSystemP2;

    private void Awake()
    {
        InputManager.OnPlayer1Spawn += Player1Spawn;
        InputManager.OnPlayer2Spawn += InputManagerFinaleOnOnPlayer2Spawn;
    }
    
    private void OnDestroy() 
    {
        InputManager.OnPlayer1Spawn -= Player1Spawn;
        InputManager.OnPlayer2Spawn -= InputManagerFinaleOnOnPlayer2Spawn;
    }

    private void Player1Spawn(PlayerController playerController)
    {
        _playerControllerP1 = playerController;
        _playerDamagedSystemP1 = playerController.gameObject.GetComponentInChildren<PlayerDamagedSystem>();
    }
    
    private void InputManagerFinaleOnOnPlayer2Spawn(PlayerController playerController) 
    {
        _playerControllerP2 = playerController;
        _playerDamagedSystemP2 = playerController.gameObject.GetComponentInChildren<PlayerDamagedSystem>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        P1WinByDeath();
        P2WinByDeath();
    }

    private void P1WinByDeath()
    {
        if (_playerDamagedSystemP2 == null) return;
        if (_playerDamagedSystemP2.HealthCurrent == 0)
        {
            Time.timeScale = 0;
            _victoryUI.SetActive(true);
        }
    }
    private void P2WinByDeath()
    {
        if (_playerDamagedSystemP1 == null) return;
        if (_playerDamagedSystemP1.HealthCurrent == 0)
        {
            Time.timeScale = 0;
            _victoryUI.SetActive(true);
        }
    }
}
