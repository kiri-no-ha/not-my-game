using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxisRaw("Horizontal");
        anim.SetBool("IsIdle", a == 0);
        anim.SetBool("Run", a != 0 && Input.GetKey(KeyCode.LeftShift) && rb.velocity.y>=0);
        anim.SetBool("Walk", a != 0 && !Input.GetKey(KeyCode.LeftShift) && rb.velocity.y >= 0);
        
        if (a < 0)
        {
            Vector3 newscale = transform.localScale;
            newscale.x = -Mathf.Abs(newscale.x);
            transform.localScale = newscale;
        }
        if (a > 0) 
        {
            Vector3 newscale = transform.localScale;
            
            newscale.x = Mathf.Abs(newscale.x);
            transform.localScale = newscale;
        }
        rb.velocity = new Vector3( a * speed, rb.velocity.y);
         

    }
}
