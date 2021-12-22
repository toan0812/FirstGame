using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public float Boss_health = 500f;
    public GameObject DeathEffect;


    public void TakeDamage(int damage)
    {
        Boss_health -= damage;
        if(Boss_health == 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
}
