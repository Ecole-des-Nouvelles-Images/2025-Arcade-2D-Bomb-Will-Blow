using __Workspaces.Alexis.Scripts.Proto.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class DashButtonFill : MonoBehaviour
{
    [SerializeField] private Image dashButton;
    [SerializeField] private TextMeshProUGUI dashTimerText;
    private __Workspaces.Alexis.Scripts.Proto.PlayerScripts.PlayerController _playerController;
    private int _dashTimerInt;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<__Workspaces.Alexis.Scripts.Proto.PlayerScripts.PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        _dashTimerInt = (int)_playerController.DashCd;
        dashButton.fillAmount = _playerController.DashCd / _playerController._timeToRefillDash;
        dashTimerText.text = _dashTimerInt.ToString();
    }
}
