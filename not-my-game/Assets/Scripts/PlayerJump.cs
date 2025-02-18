using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private bool Isground;
    public LayerMask layerground;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position, Vector2.down, Color.blue);
        
        if (Physics2D.Raycast(transform.position, Vector2.down, layerground))
        {
            Debug.Log("TRUE");
            Isground = true;
        }
        else {Isground = false; Debug.Log("False"); }
             
        


        if(Input.GetKey(KeyCode.Space) && Isground)
        {
            rb.AddForce(new Vector2(0, 5));
        }
    }
}
