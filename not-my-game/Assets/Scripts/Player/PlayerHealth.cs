using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health; 
    private float maxHealth=5;
    private Vector3 start_pos;
    void Start()
    {
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Death();
        }
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
        Debug.Log($"{health}-{damage}={health-damage}");    
        
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
    public void Death()
    {
        health = maxHealth;
        transform.position = start_pos;
    }
    public float GetHealth { get { return health; } }
}
