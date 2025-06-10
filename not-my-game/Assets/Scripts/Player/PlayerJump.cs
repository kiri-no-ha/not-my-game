using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private bool Isground;
    private PlayerMove pl;
    [SerializeField] private LayerMask layerground;
    [SerializeField] private LayerMask layerground_right;
    [SerializeField] private LayerMask layerground_left;
    [SerializeField] private float jumppower;
    private CapsuleCollider2D BoxCollider2D;
    private Animator anim;
    private float jump_counter;
    public  float jump_counter_max;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D = rb.GetComponent<CapsuleCollider2D>();
        pl = GetComponent<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxisRaw("Horizontal");
        jump_counter+= Time.deltaTime;

        anim.SetBool("Fall", !IsGround() && rb.velocity.y <= 0 && a == 0);
        anim.SetBool("Fall_Side", !IsGround() && rb.velocity.y <= 0 && a != 0);

        if (Input.GetKey(KeyCode.Space) && IsGround())
        {
            rb.AddForce(new Vector2(0, jumppower));
            jump_counter = 0;
            if (a == 0)
            {
                anim.SetTrigger("Jump");
            }
            else
            {
                anim.SetTrigger("Jump_Side");
            }
            if (!IsGround() && IsOnWall())
            {
                RaycastHit2D ray_left = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0, Vector2.left, 0.1f, layerground_left);
                RaycastHit2D ray_raight = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0, Vector2.right, 0.1f, layerground_right);
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                if (ray_left.collider != null)
                {
                    if (a > 0)
                    {
                        rb.velocity = new Vector2(Mathf.Sign(a) * pl.speed, rb.velocity.y);
                    }
                    if (a < 0)
                    {
                        rb.velocity = new Vector2(-Mathf.Sign(a) * pl.speed, rb.velocity.y);
                    }
                }
                if ((ray_left.collider != null))
                {
                    if (a < 0)
                    {
                        rb.velocity = new Vector2(Mathf.Sign(a) * pl.speed, rb.velocity.y);
                    }
                    if (a > 0)
                    {
                        rb.velocity = new Vector2(-Mathf.Sign(a) * pl.speed, rb.velocity.y);
                    }
                }
                rb.gravityScale = 0;

            }
        }
    }
    public bool IsGround()
    {
        
           RaycastHit2D ray = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0, Vector2.down, 0.1f, layerground);
            return ray.collider != null;
        
        
    }
    public bool IsOnWall()
    {
        RaycastHit2D ray_left = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0, Vector2.left, 0.1f, layerground_left);
        RaycastHit2D ray_raight = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0, Vector2.right, 0.1f, layerground_right);
        return ray_left.collider!=null || ray_raight.collider!=null;
    }

}
