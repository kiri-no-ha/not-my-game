using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Rendering;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    public float speed_run;
    public float speed_walk;
    private bool RUN;
    public float x=1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed_run = (float)speed * 2;
        speed_walk = (float)speed;
    }

    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxisRaw("Horizontal");
        RUN = a != 0 && Input.GetKey(KeyCode.LeftShift) && rb.velocity.y >= 0;
        anim.SetBool("IsIdle", a == 0);
        anim.SetBool("Run", RUN);
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
        if (RUN)
        {
            speed = speed_run;
        }
        else
        {
            speed = speed_walk;
        }
        rb.velocity = new Vector3( a * speed * x, rb.velocity.y);
         

    }
    public void ChangeSpeed(float newspeed)
    {
         x*=newspeed;
    }
}
