using UnityEngine;

public class SoundToPause : MonoBehaviour
{
    [SerializeField] private GameObject _SoundMenu;
    [SerializeField] private GameObject _PauseMenu;

    public void PauseMenuFromSound()
    {
        _SoundMenu.SetActive(false);
        _PauseMenu.SetActive(true);
    }
}
