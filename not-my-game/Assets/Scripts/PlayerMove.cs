using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxisRaw("Horizontal")*speed;
        if (a < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (a > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        rb.velocity = new Vector3( a, rb.velocity.y);
         

    }
}
