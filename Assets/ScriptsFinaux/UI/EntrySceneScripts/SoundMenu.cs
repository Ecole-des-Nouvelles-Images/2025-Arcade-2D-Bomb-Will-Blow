using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    [SerializeField] private GameObject _SoundMenu;
    [SerializeField] private GameObject _MainMenu;
    [SerializeField] private GameObject _Ninjas;
    
    public void SoundParameters()
    {
        _MainMenu.SetActive(false);
        _Ninjas.SetActive(false);
        _SoundMenu.SetActive(true);
    }
}
