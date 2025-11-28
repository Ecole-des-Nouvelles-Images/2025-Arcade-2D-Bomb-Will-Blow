using System;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private PlayerStats _playerStats;
    private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(_damage);
        }
    }
}
