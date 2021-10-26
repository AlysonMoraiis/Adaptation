using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    public bool grounded;
    private bool jumping;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public ParticleSystem dust;
    public LayerMask whatIsGround;

    public Animator anim;


    public Transform groundCheck;
    
    
    private Rigidbody2D rb2d;
    //public Animator anim;



    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
       
        {
            if (grounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                CreateDust();
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb2d.velocity = Vector2.up * jumpForce;
            }
            
            //anim.SetBool("JumpFall", rb2d.velocity.y != 0);

            if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
                if(jumpTimeCounter > 0)
                {
                    rb2d.velocity = Vector2.up * jumpForce;
                    //jumping = true;
                    jumpTimeCounter -= Time.deltaTime;
                } else
                {
                    isJumping = false;
                }
            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }
        }
            
    }

    void CreateDust() 
    {
        dust.Play();
    }
}
