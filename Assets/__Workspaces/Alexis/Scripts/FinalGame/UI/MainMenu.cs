using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("__Workspaces/Alexis/Scenes/EntrySceneTest");
    }
}
