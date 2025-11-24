using UnityEngine;
using UnityEngine.UI;
public class FuelBarScript : MonoBehaviour
{
    [SerializeField] private Image _FuelBar;
    [SerializeField] private Image _FuelButton;
    private PlayerController _playerController;
    
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    
    void Update()
    {
        _FuelBar.fillAmount = _playerController.JetpackFuel / 5;
        _FuelButton.fillAmount = _playerController.JetpackFuel / 5;
    }
}
