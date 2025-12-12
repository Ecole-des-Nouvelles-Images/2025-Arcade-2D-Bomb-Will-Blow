using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("__Workspaces/Alexis/Scenes/EntrySceneTest");
    }
}
