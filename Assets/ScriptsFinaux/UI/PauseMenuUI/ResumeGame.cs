using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    [SerializeField] private GameObject _PauseMenu;

    public void ClosePauseMenu()
    {
        Time.timeScale = 1;
        _PauseMenu.SetActive(false);
    }
}
