using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    private void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 )
        {
            animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }

    }

    private void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
