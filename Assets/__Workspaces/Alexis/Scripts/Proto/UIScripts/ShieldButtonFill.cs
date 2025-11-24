using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButtonFill : MonoBehaviour
{
    [SerializeField] private Image shieldButon;
    [SerializeField] private TextMeshProUGUI shieldTimerText;
    private PlayerController _playerController;
    private int _shieldTimerInt;
    
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        _shieldTimerInt = (int)_playerController.ShieldTimer;
        shieldButon.fillAmount = _playerController.ShieldTimer / 5;
        shieldTimerText.text = _shieldTimerInt.ToString();
    }
}
