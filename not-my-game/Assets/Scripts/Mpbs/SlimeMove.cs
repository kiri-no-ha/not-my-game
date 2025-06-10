using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField]  private float speedBoost;
    [SerializeField] private float jump;
    [SerializeField] private float distanceAngry;
    [SerializeField] private float distancepatrol;
    [SerializeField] private GameObject player;

    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    private Animator anim;
    private Rigidbody2D rb;
    private bool patrol = true;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        minDistance = transform.position.x - distancepatrol; 
        maxDistance = transform.position.x + distancepatrol; speed = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol)
        {
            Patrol();
        }
        //else
        //Angree();
        //if (Vector2.Distance(transform.position, player.transform.position) < distanceAngry)
        //{
        //    Mathf.Abs(speed);
        //    patrol = false;
        //}
        //else
        //{
        //    patrol = true;
        //}


    }
    private void Patrol()
    {
        transform.Translate(transform.right * Time.deltaTime * speed);

        if(transform.position.x > maxDistance)
        {
            speed = -speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x < minDistance)
        {
            speed = -speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void Angree()
    {
        if (patrol == false)
        {
            Vector2 moveVector = Vector2.MoveTowards(transform.position, player.transform.position, speedBoost*speed*Time.deltaTime);
            transform.position = new Vector2(moveVector.x, transform.position.y);
            if (transform.position.x > player.transform.position.x)
            {
                speed = -speed;
                transform.rotation = Quaternion.Euler(0, 9, 0);
            }
            if (transform.position.x < player.transform.position.x)
            {
                speed = -speed;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        
    }
}
