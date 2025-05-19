using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float maxHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void GiveDamage(float damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
        }
        else { health = 0; }
    }
    public void AddHealth(float healthh)
    {
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healthh;
        }
    }
}
