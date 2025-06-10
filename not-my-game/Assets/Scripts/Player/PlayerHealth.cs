using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
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
    
    
    public void Death()
    {
        health = maxHealth;
        transform.position = start_pos;
    }
   
}
