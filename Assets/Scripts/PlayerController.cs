using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float Speed;

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovementAnimation(horizontal, vertical);

        // play crouch animation
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if(animator != null)
            {
                animator.SetBool("Crouch", true);
            }
        }
        else
        {
            if(animator != null)
            {
                animator.SetBool("Crouch", false);
            }
        }
        
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        if(animator != null)
        {
            // Setting float value of speed inside animator
            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            // Setting value of 'jump' boolean
            if (vertical > 0)
            {
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }
        }

        // Change the direction of player
        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

}
