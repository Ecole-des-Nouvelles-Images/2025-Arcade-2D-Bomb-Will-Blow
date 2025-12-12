using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour
{
    private Scene currentScene;

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void Replay()
    {
        SceneManager.LoadScene(currentScene.name);
    }
}
