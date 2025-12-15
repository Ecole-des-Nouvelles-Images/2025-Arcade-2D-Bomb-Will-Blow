using UnityEngine;

public class VictoryAfterDeath : MonoBehaviour
{
    [SerializeField] private GameObject _victoryUI;
    
    private PlayerControllerFinal  _playerControllerP1;
    private PlayerControllerFinal  _playerControllerP2;



    private void Awake()
    {
        
        InputManagerFinale.OnPlayer1Spawn += Player1Spawn;
        InputManagerFinale.OnPlayer2Spawn += InputManagerFinaleOnOnPlayer2Spawn;
    }
    
    private void OnDestroy() {
        InputManagerFinale.OnPlayer1Spawn -= Player1Spawn;
        InputManagerFinale.OnPlayer2Spawn -= InputManagerFinaleOnOnPlayer2Spawn;
    }

    private void InputManagerFinaleOnOnPlayer2Spawn(PlayerControllerFinal playerControllerFinal) 
    {
        _playerControllerP2 = playerControllerFinal;
    }

    private void Player1Spawn(PlayerControllerFinal playerControllerFinal)
    {
        _playerControllerP1 = playerControllerFinal;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
