using System;
using UnityEngine;

public class DeactivateBomb : MonoBehaviour
{
    [SerializeField] private GameObject _VictorySceneP1;
    [SerializeField] private GameObject _VictorySceneP2;
    
    private GameObject _p1;
    private GameObject _p2;

    private PlayerControllerFinal _bombP1;
    private PlayerControllerFinal _bombP2;

    private bool _foundP1;
    private bool _foundP2;

    void Update()
    {
        if (!_foundP1)
        {
            _p1 = GameObject.FindGameObjectWithTag("Player");
            
            _bombP1 = _p1.GetComponent<PlayerControllerFinal>();

            if (_bombP1 != null)
            {
                _foundP1 = true;
            }
        }

        if (!_foundP2)
        {
            _p2 = GameObject.FindGameObjectWithTag("Player2");
            
            _bombP2 = _p2.GetComponent<PlayerControllerFinal>();
            if (_bombP2 != null)
            {
                _foundP2 = true;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _bombP1.CanDeactivateBomb =  true;
        }

        if (other.tag == "Player2")
        {
            _bombP2.CanDeactivateBomb  =  true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _bombP1.CanDeactivateBomb =  false;
        }

        if (other.tag == "Player2")
        {
            _bombP2.CanDeactivateBomb  =  false;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        if (_bombP1.CanDeactivateBomb)
        {
            _VictorySceneP1.SetActive(true);
        }
        if (_bombP2.CanDeactivateBomb)
        {
            _VictorySceneP2.SetActive(true);
        }
    }
}
