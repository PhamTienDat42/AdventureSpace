using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float moveInput;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private bool canDoubleJump = false;
    [SerializeField] private Collider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling }
    [SerializeField] private AudioSource jumpingSoundEffect;
   
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        MovementState state;
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(moveInput < 0f)
        {
            spriteRenderer.flipX = true;
            state = MovementState.running;      
        } else if(moveInput > 0f)
        {
            spriteRenderer.flipX = false;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } else if(rb.velocity.y < -.1f) {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
        if(isGrounded())
        {
            canDoubleJump = true;
        }
    }

    //Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canDoubleJump = true;
            jumpingSoundEffect.Play();
        }

        else if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canDoubleJump = false;
            jumpingSoundEffect.Play();
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
