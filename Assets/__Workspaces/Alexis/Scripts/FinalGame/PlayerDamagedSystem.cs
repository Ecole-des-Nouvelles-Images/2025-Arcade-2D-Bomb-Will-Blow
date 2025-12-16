using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerDamagedSystem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [SerializeField] private List<GameObject> _HeartContainersP1;
    [SerializeField] private List<GameObject> _HeartContainersP2;
    
    public int Health = 5;
    //public bool _playerDamaged;

    private void Start()
    {
    }
    
    private void Update()
    {
        
        //if (_playerDamaged) ManagerHeathDisplay();
        /*if (_playerDamaged && gameObject.CompareTag("Player1Hurtbox"))
        {
            switch (Health)
            {
                case 4 : 
                    _HeartContainersP1[4].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 4");
                    break;
                case 3 :
                    _HeartContainersP1[3].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 3");
                    break;
                case 2 :
                    _HeartContainersP1[2].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 2");
                    break;
                case 1 :
                    _HeartContainersP1[1].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 1");
                    break;
                case 0 :
                    _HeartContainersP1[0].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 0");
                    break;
                default:
                    _playerDamaged = false;
                    break;
            }
        }

        if (_playerDamaged && gameObject.CompareTag("Player2Hurtbox"))
        {
            switch (Health)
            {
                case 4:
                    _HeartContainersP2[4].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 4");
                    break;
                case 3:
                    _HeartContainersP2[3].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 3");
                    break;
                case 2:
                    _HeartContainersP2[2].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 2");
                    break;
                case 1:
                    _HeartContainersP2[1].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 1");
                    break;
                case 0:
                    _HeartContainersP2[0].SetActive(false);
                    _playerDamaged = false;
                    Debug.Log("Case 0");
                    break;
                default:
                    _playerDamaged = false;
                    break;
            }
        }
*/
        if (Health == 0)
        {
            OnDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }

        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
    }
    
    private void OnDeath()
    {
        Destroy(player);
    }

    public void TakeDamage() {
    //    _playerDamaged = true;
        Health--;
        if( gameObject.CompareTag("Player1Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer1(Health);
        if( gameObject.CompareTag("Player2Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer2(Health);
    }

    private void ManagerHeathDisplay() {
        /*if (gameObject.CompareTag("Player1Hurtbox")) {
            for (int i = 0; i < _HeartContainersP1.Count; i++) {
                if (_HeartContainersP1[i] == null) continue;
                _HeartContainersP1[i].SetActive(Health > i);
            }
        }

        if (gameObject.CompareTag("Player2Hurtbox")) {
            for (int i = 0; i < _HeartContainersP2.Count; i++) {
                if (_HeartContainersP2[i] == null) continue;
                _HeartContainersP2[i].SetActive(Health > i);
            }
        }*/
   //     _playerDamaged = false;
    }
}
