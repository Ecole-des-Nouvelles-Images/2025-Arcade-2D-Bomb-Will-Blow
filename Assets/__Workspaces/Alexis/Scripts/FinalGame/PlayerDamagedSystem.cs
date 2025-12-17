using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerDamagedSystem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [SerializeField] private List<GameObject> _HeartContainersP1;
    [SerializeField] private List<GameObject> _HeartContainersP2;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material originalMaterial;
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float _Maxduration;
    private float _duration;
    private bool _damaged = false;
    
    public int Health = 5;
    //public bool _playerDamaged;

    private void Start()
    {
    }
    
    private void Update()
    {
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

        if (_damaged)
        {
            _duration += Time.deltaTime;
            Debug.Log("Time since las hit = " + _duration + " seconds.");
            if (_duration >= _Maxduration)
            {
                spriteRenderer.material = originalMaterial;
                _damaged = false;
            }
        }
    }
    
    private void OnDeath()
    {
        Destroy(player);
    }

    public void TakeDamage() {
    //    _playerDamaged = true;
        Health--;
        _duration = 0;
        if( gameObject.CompareTag("Player1Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer1(Health);
        if( gameObject.CompareTag("Player2Hurtbox")) HeartsOnUI.Instance.DislayHeathPlayer2(Health);
        _damaged = true;
        spriteRenderer.material = flashMaterial;
    }
}
