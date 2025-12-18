using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour
{
    private Scene currentScene;
    
    [SerializeField] private GameObject _VictoryScreenFromDeath;
    [SerializeField] private GameObject _VictoryScreenFromBomb;
    
    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void Replay()
    {
        _VictoryScreenFromBomb.SetActive(false);
        _VictoryScreenFromDeath.SetActive(false);
        SceneManager.LoadScene(currentScene.name);
    }
}