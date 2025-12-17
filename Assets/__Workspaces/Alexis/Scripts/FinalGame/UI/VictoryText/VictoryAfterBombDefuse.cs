using TMPro;
using UnityEngine;

public class VictoryAfterBombDefuse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _VictoryByDeathText;
    
    [SerializeField] private ActivateVictoryUI _victoryUI;
    
    private void Awake() 
    {
        Debug.Log(_victoryUI.P1Win);
        Debug.Log(_victoryUI.P2Win);
        if (_victoryUI.P1Win)
        {
            Player1WinsText();
        }

        if (_victoryUI.P1Win)
        {
            Player2WinsText();
        }
    }
    
    private void Player1WinsText()
    {
        _VictoryByDeathText.text = "Le joueur 2 a désactivé la bombe avant le joueur 1! Il a gagné ! Bravo !";
    }

    private void Player2WinsText()
    {
        _VictoryByDeathText.text = "Le joueur 1 a désactivé la bombe avant le joueur 2! Il a gagné ! Bravo !";
    }
}
