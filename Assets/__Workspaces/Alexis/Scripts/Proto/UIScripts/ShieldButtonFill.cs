using __Workspaces.Alexis.Scripts.Proto.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButtonFill : MonoBehaviour
{
    [SerializeField] private Image shieldButon;
    [SerializeField] private TextMeshProUGUI shieldTimerText;
    private __Workspaces.Alexis.Scripts.Proto.PlayerScripts.PlayerController _playerController;
    private int _shieldTimerInt;
    
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<__Workspaces.Alexis.Scripts.Proto.PlayerScripts.PlayerController>();
    }

    void Update()
    {
        _shieldTimerInt = (int)_playerController.ShieldTimer;
        shieldButon.fillAmount = _playerController.ShieldTimer / 5;
        shieldTimerText.text = _shieldTimerInt.ToString();
    }
}
