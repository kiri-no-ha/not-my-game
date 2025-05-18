using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< Updated upstream
    private bool isSlow;
    public float slow;
    void Start()
    {
        isSlow = false;
=======
    public float slowing = 1;
    private float start_speed;
    void Start()
    {
        
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if(collision.gameObject.tag == "Player")
            {
                if (!isSlow)
                {
                    collision.gameObject.GetComponent<PlayerMove>().ChangeSpeed(1/slow);
                    isSlow = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
=======
        Debug.Log(start_speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
>>>>>>> Stashed changes
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player")
            {
<<<<<<< Updated upstream
                collision.gameObject.GetComponent<PlayerMove>().ChangeSpeed(slow);
                isSlow = false;
=======
                start_speed = collision.gameObject.GetComponent<PlayerMove>().speed;
                collision.gameObject.GetComponent<PlayerMove>().speed /= slowing;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerMove>().speed = start_speed;
>>>>>>> Stashed changes
            }
        }
    }
}
