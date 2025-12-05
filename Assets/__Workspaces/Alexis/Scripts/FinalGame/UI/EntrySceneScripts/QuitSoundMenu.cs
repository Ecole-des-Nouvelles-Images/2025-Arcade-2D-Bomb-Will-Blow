using UnityEngine;

public class QuitSoundMenu : MonoBehaviour
{
    [SerializeField] private GameObject _SoundMenu;

    public void QuitSoundParameters()
    {
        _SoundMenu.SetActive(false);
    }
}
