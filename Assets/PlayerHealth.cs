using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    private bool isDead;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

    public void Heal(float recovery)
    {
        if (health + recovery < maxHealth)
        {
            health += recovery;
        }
    }

    public void Die()
    {
        isDead = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 10;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
