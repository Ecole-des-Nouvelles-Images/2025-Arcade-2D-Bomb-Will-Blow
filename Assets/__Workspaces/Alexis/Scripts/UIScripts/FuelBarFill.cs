using UnityEngine;
using UnityEngine.UI;
public class FuelBarScript : MonoBehaviour
{
    [SerializeField] private Image _FuelBar;
    private PlayerController _playerController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        _FuelBar.fillAmount = _playerController.JetpackFuel / 5;
    }
}
