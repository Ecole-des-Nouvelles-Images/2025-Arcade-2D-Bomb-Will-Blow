using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    [SerializeField] private GameObject _SoundMenu;

    public void SoundParameters()
    {
        _SoundMenu.SetActive(true);
    }
}
