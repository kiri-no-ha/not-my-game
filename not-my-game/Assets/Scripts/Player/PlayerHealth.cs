using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health; 
    private float maxHealth=5;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        if (health - damage < 0)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }
    }
    public void AddDamage(float addhp)
    {
        if (health + addhp > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += addhp;
        }
    }
    public float GetHealth { get { return health; } }
}
