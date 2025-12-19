using ScriptsFinaux;
using ScriptsFinaux.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryByDeath : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _VictoryByDeathText;
    
    private PlayerController _playerControllerP1;
    private PlayerController _playerControllerP2;
    
    private void Awake() {
        InputManager.OnPlayer1Spawn += Player1Spawn;
        InputManager.OnPlayer2Spawn += InputManagerFinaleOnOnPlayer2Spawn;
        
        if (GameObject.FindWithTag("Player") != null)
        {
            Player1WinsText();
        }

        if (GameObject.FindWithTag("Player2") != null)
        {
            Player2WinsText();
        }
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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Player1WinsText()
    {
        _VictoryByDeathText.text = "Le joueur 1 est mort ! Le joueur 2 à gagné ! Bravo !";
    }

    private void Player2WinsText()
    {
        _VictoryByDeathText.text = "Le joueur 2 est mort ! Le joueur 1 à gagné ! Bravo !";
    }
}
