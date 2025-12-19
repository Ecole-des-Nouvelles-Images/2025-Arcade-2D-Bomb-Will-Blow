using __Workspaces.Alexis.Scripts.Proto.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;
public class FuelBarScript : MonoBehaviour
{
    [SerializeField] private Image _FuelBar;
    [SerializeField] private Image _FuelButton;
    private __Workspaces.Alexis.Scripts.Proto.PlayerScripts.PlayerController _playerController;
    
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<__Workspaces.Alexis.Scripts.Proto.PlayerScripts.PlayerController>();
    }
    
    void Update()
    {
        _FuelBar.fillAmount = _playerController.JetpackFuel / 5;
        _FuelButton.fillAmount = _playerController.JetpackFuel / 5;
    }
}
