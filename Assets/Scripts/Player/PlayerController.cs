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

    private void Awake()
    {
        animator = GetComponent<Animator>();
        facingRight = true;
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Mathf.Abs(horizontal)>0 || vertical>0)
        {
            Debug.Log("h and v");
            Movement(horizontal,vertical);
        }
    }

    void Movement(float h,float v)
    {
       
        if (Mathf.Abs(h)>0)
        {
            Debug.Log(h);
            if (h>0)
            {
                if (!facingRight) flip();
            }
            else if (h<0)
            {
                if (facingRight) flip();
            }
            animator.SetFloat(speed, Mathf.Abs(h));
        }
        else if(v>0)
        {

        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
