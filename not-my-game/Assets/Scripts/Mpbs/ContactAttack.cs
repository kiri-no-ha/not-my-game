using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAttack : MonoBehaviour
{
    public float damage;
    private bool start_colider;
    private bool kys;
    // Start is called before the first frame update
    void Start()
    {
        start_colider = true;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (start_colider)
                {
                    Debug.Log("ColiderEnter");
                    collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                    start_colider=false;
                    kys = false;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                start_colider=true;
                
            }
        }
    }
}
