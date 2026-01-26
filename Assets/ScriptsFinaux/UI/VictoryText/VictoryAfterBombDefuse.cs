using ScriptsFinaux.Player;
using TMPro;
using UnityEngine;

public class VictoryAfterBombDefuse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _VictoryByDeathText;
    [SerializeField] private ActivateVictoryUI _victoryUI;
    private PlayerController _playerController;
    
    private void Awake() 
    {
        _playerController = FindObjectOfType<PlayerController>();
        
        if (_playerController.PlayerData.P1Win)
        {
            Player1WinsText();
        }

        if (_playerController.PlayerData.P2Win)
        {
            Player2WinsText();
        }
    }
    
    private void Player1WinsText()
    {
        _VictoryByDeathText.text = "Le joueur 1 a désactivé la bombe avant le joueur 2! Il a gagné ! Bravo !";
    }

    private void Player2WinsText()
    {
        _VictoryByDeathText.text = "Le joueur 2 a désactivé la bombe avant le joueur 1! Il a gagné ! Bravo !";
    }
}
