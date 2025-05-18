using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isSlow;
    public float slow;
    void Start()
    {
        isSlow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision!=null)
        {
            if(collision.gameObject.tag == "Player")
            {
                if (!isSlow)
                {
                    Debug.Log(collision.gameObject.GetComponent<PlayerMove>()!=null);
                    isSlow = true;
                    collision.gameObject.GetComponent<PlayerMove>().ChangeSpeed(1/slow); 
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
                if (isSlow)
                {
                    isSlow = false;
                    collision.gameObject.GetComponent<PlayerMove>().ChangeSpeed(1 / slow);
                }
            }
        }
    }
}
