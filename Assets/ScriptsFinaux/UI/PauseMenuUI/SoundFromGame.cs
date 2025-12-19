using UnityEngine;

public class SoundFromGame : MonoBehaviour
{
    [SerializeField] private GameObject _SoundMenu;
    [SerializeField] private GameObject _PauseMenu;

    public void SoundMenuFromGame()
    {
        _SoundMenu.SetActive(true);
        _PauseMenu.SetActive(false);
    }
}
