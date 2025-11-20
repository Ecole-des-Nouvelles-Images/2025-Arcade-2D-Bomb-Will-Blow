using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarFill : MonoBehaviour
{
    [SerializeField] private Image _HealthBar;
    private PlayerStats _playerStats;
    
    void Start()
    {
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        _HealthBar.fillAmount = _playerStats.HpAmount / _playerStats.MaxHpAmount;
    }
}
