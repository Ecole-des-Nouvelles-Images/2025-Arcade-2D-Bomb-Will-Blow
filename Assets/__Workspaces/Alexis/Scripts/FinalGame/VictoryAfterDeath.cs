using UnityEngine;

public class VictoryAfterDeath : MonoBehaviour
{
    [SerializeField] private GameObject _victoryUI;
    
    private PlayerControllerFinal  _playerControllerP1;
    private PlayerControllerFinal  _playerControllerP2;

    private PlayerDamagedSystem _playerDamagedSystemP1;
    private PlayerDamagedSystem _playerDamagedSystemP2;

    private void Awake()
    {
        InputManagerFinale.OnPlayer1Spawn += Player1Spawn;
        InputManagerFinale.OnPlayer2Spawn += InputManagerFinaleOnOnPlayer2Spawn;
    }
    
    private void OnDestroy() 
    {
        InputManagerFinale.OnPlayer1Spawn -= Player1Spawn;
        InputManagerFinale.OnPlayer2Spawn -= InputManagerFinaleOnOnPlayer2Spawn;
    }

    private void Player1Spawn(PlayerControllerFinal playerControllerFinal)
    {
        _playerControllerP1 = playerControllerFinal;
        _playerDamagedSystemP1 = playerControllerFinal.gameObject.GetComponentInChildren<PlayerDamagedSystem>();
    }
    
    private void InputManagerFinaleOnOnPlayer2Spawn(PlayerControllerFinal playerControllerFinal) 
    {
        _playerControllerP2 = playerControllerFinal;
        _playerDamagedSystemP2 = playerControllerFinal.gameObject.GetComponentInChildren<PlayerDamagedSystem>();
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
        if (_playerDamagedSystemP2.Health == 0)
        {
            Time.timeScale = 0;
            _victoryUI.SetActive(true);
        }
    }
    private void P2WinByDeath()
    {
        if (_playerDamagedSystemP1 == null) return;
        if (_playerDamagedSystemP1.Health == 0)
        {
            Time.timeScale = 0;
            _victoryUI.SetActive(true);
        }
    }
}
