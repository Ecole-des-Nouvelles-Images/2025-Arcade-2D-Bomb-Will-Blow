using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarFill : MonoBehaviour
{
    [SerializeField] private Image _HealthBar;
    private PlayerStats _playerStats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        _HealthBar.fillAmount = _playerStats.HpAmount / _playerStats.MaxHpAmount;
    }
}
