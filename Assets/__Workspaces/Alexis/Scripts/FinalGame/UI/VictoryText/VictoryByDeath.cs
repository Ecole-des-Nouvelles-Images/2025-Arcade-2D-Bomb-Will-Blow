using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryByDeath : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _VictoryByDeathText;
    
    private PlayerControllerFinal _playerControllerP1;
    private PlayerControllerFinal _playerControllerP2;
    
    private void Awake() {
        InputManagerFinale.OnPlayer1Spawn += Player1Spawn;
        InputManagerFinale.OnPlayer2Spawn += InputManagerFinaleOnOnPlayer2Spawn;
        
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
        InputManagerFinale.OnPlayer1Spawn -= Player1Spawn;
        InputManagerFinale.OnPlayer2Spawn -= InputManagerFinaleOnOnPlayer2Spawn;
    }

    private void InputManagerFinaleOnOnPlayer2Spawn(PlayerControllerFinal playerControllerFinal) {
        _playerControllerP2 = playerControllerFinal;
    }

    private void Player1Spawn(PlayerControllerFinal playerControllerFinal) {
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

    private void Player1WinsText()
    {
        _VictoryByDeathText.text = "Le joueur 1 est mort ! Le joueur 2 à gagné ! Bravo !";
    }

    private void Player2WinsText()
    {
        _VictoryByDeathText.text = "Le joueur 2 est mort ! Le joueur 1 à gagné ! Bravo !";
    }
}
