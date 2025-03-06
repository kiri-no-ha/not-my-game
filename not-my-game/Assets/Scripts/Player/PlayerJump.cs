using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private bool Isground;
    [SerializeField] private LayerMask layerground;
    [SerializeField] private LayerMask layerground_right;
    [SerializeField] private LayerMask layerground_left;
    [SerializeField] private float jumppower;
    private BoxCollider2D BoxCollider2D;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D = rb.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        anim.SetBool("Fall", !IsGround() && rb.velocity.y<0);
        if(Input.GetKey(KeyCode.Space) && IsGround())
        {
            rb.AddForce(new Vector2(0, jumppower));
        }
        if (!IsGround() && IsOnWall())
        {

        }
    }
    public bool IsGround()
    {
        RaycastHit2D ray = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0, Vector2.down, 0.1f, layerground);
        return ray.collider!=null;
    }
    public bool IsOnWall()
    {
        RaycastHit2D ray_left = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0, Vector2.left, 0.1f, layerground_left);
        RaycastHit2D ray_raight = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0, Vector2.right, 0.1f, layerground_right);
        return ray_left.collider!=null || ray_raight.collider!=null;
    }

}
