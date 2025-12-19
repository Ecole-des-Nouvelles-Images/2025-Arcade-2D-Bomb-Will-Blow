using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    [SerializeField] private GameObject _SoundMenu;
    [SerializeField] private GameObject _MainMenu;

    public void SoundParameters()
    {
        _MainMenu.SetActive(false);
        _SoundMenu.SetActive(true);
    }
}
