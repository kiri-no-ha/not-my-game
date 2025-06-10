using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public  float maxHealth = 5;
    void Start()
    {
        
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
        Debug.Log($"{health}-{damage}={health - damage}");

    }
    public void AddHealth(float addhp)
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
