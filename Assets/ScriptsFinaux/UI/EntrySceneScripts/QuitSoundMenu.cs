using UnityEngine;

public class QuitSoundMenu : MonoBehaviour
{
    [SerializeField] private GameObject _SoundMenu;
    [SerializeField] private GameObject _MainMenu;
    [SerializeField] private GameObject _Ninjas;

    public void QuitSoundParameters()
    {
        _SoundMenu.SetActive(false);
        _Ninjas.SetActive(true);
        _MainMenu.SetActive(true);
    }
}
