using UnityEngine;

public class QuitSoundMenu : MonoBehaviour
{
    [SerializeField] private GameObject _SoundMenu;
    [SerializeField] private GameObject _MainMenu;

    public void QuitSoundParameters()
    {
        _SoundMenu.SetActive(false);
        _MainMenu.SetActive(true);
    }
}
