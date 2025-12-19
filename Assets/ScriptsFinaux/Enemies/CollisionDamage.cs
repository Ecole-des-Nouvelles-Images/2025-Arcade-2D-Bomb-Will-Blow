using System;
using ScriptsFinaux.Player;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private PlayerDamagedSystem playerDamagedSystem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player2")
        {
            playerDamagedSystem = other.GetComponentInChildren<PlayerDamagedSystem>();
            if (playerDamagedSystem.HealthCurrent != 0)
            {
                playerDamagedSystem.TakeDamage();
                return;
            }
            playerDamagedSystem.OnDeath();
        }
    }
}
