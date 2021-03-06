﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    static public float moveSpeed = 6f;
    public Rigidbody2D rb;

    public Animator animator;
    static public bool frozen = false;

    Vector2 movement;

    // Update is called once per frame
    private void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (!frozen)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
    }

    private void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.sqrMagnitude > 0.01f && !IsInvoking("playStepSound"))
            InvokeRepeating("playStepSound", 0, 0.5f);
        else if (movement.sqrMagnitude < 0.01f)
            CancelInvoke();
    }
    public void playStepSound()
    {
        FindObjectOfType<AudioManager>().Play("HeroWalk");
    }
}
