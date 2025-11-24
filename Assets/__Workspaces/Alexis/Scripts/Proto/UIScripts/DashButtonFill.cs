using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class DashButtonFill : MonoBehaviour
{
    [SerializeField] private Image dashButton;
    [SerializeField] private TextMeshProUGUI dashTimerText;
    private PlayerController _playerController;
    private int _dashTimerInt;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        _dashTimerInt = (int)_playerController._dashCd;
        dashButton.fillAmount = _playerController._dashCd / _playerController._timeToRefillDash;
        dashTimerText.text = _dashTimerInt.ToString();
    }
}
