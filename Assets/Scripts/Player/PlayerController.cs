using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Animation-Components
    const string speed = "Speed";
    const string crouch = "Crouch";
    const string jump = "Jump";
    Animator animator;
    bool facingRight = true;
    bool isCrouching = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        facingRight = true;
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);

        bool canJump = Input.GetKey(KeyCode.Space);
        Jump(canJump);

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
    void Jump(bool canJump)
    {
        if(canJump) animator.SetBool(jump, true);

        else animator.SetBool(jump,false);
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
