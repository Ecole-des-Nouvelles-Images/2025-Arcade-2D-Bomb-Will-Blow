using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }
}
