using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Animation-Components
    const string speed = "Speed";
    const string crouch = "Crouch";
    const string verticalSpeed = "VerticalSpeed";
    const string isJumping = "IsJumping";
    const string grounded = "IsGrounded";
    Animator animator;
    bool facingRight = true;


    //Jump
    Rigidbody2D rb;
    [SerializeField] float jumpForce;

    //Ground-Check
    [SerializeField] Transform groundPoint;
    bool isGrounded;
    [SerializeField] LayerMask groundLayer;

    //Crouch
    BoxCollider2D playerCollider;
    [SerializeField] float crouchYSize;
    [SerializeField] float crouchYOffset;
    Vector2 normalSize;
    Vector2 normalOffset;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        playerCollider = GetComponent<BoxCollider2D>();
        normalSize = playerCollider.size;
        normalOffset = playerCollider.offset;
    }
    private void FixedUpdate()
    {
        //Ground-Check
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, 1f, groundLayer);
        animator.SetBool(grounded, isGrounded);
    }
    private void Update()
    {
        
        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        //Jump
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        JumpAnimation();
        //Crouch
        Crouch(Input.GetKey(KeyCode.LeftControl));
        //Movement
        Movement(horizontal);
        
    }
    void Crouch(bool status)
    { 
        if (status && animator.GetBool(crouch) || !status && !animator.GetBool(crouch))
            return;
         animator.SetBool(crouch, status);
        
        if (status)
        {
            playerCollider.size = new Vector2(playerCollider.size.x,crouchYSize);
            playerCollider.offset = new Vector2(playerCollider.offset.x, crouchYOffset);
        }
        else
        {
            playerCollider.size = normalSize;
            playerCollider.offset = normalOffset;
        }
    }
    void Movement(float h)
    {
        if (Mathf.Abs(h) > 0)
        {
            if (h > 0)
            {
                if (!facingRight) flip();
            }
            else if (h < 0)
            {
                if (facingRight) flip();
            }
            animator.SetFloat(speed, Mathf.Abs(h));
        }
    }
    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);  
    }
    void JumpAnimation()
    {
        animator.SetFloat(verticalSpeed, rb.velocity.y);
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
