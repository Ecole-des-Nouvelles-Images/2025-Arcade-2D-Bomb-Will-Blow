using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float HpAmount;
    public float MaxHpAmount = 5;

    void Start()
    {
        HpAmount = MaxHpAmount;
    }

    void Update()
    {
        if (HpAmount == 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        HpAmount -= damage;
        Debug.Log(HpAmount);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
