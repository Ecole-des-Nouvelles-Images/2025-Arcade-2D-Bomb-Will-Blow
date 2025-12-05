using System;
using UnityEngine;

public class PlayerDamagedSystem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    public int Health = 5;
    public bool _playerDamaged;
    public bool _playerHealed;
    
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
    }
    
    private void OnDeath()
    {
        Destroy(player);
    }

    public void TakeDamage()
    {
        _playerDamaged = true;
        Health--;
    }

    public void Heals()
    {
        _playerHealed = true;
        Health++;
    }
}
