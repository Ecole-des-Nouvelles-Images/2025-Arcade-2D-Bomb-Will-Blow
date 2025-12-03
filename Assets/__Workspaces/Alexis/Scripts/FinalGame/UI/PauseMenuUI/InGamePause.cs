using UnityEngine;

public class InGamePause : MonoBehaviour
{
    [SerializeField] private GameObject _PauseMenu;

    public void OpenPauseMenu()
    {
        Time.timeScale = 0;
        _PauseMenu.SetActive(true);
    }
}
