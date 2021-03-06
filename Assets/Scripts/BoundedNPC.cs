﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactable
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;

    private bool stopped;


    // Start is called before the first frame update
    void Start()
    {
        //moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        //waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        anim = GetComponent<Animator>();

        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
        Invoke("RandomStop", 0.5f);
        Invoke("RandomGo", 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((!playerInRange) && (!anim.GetBool("Stopped")))
        {
            Move();
                
        }

    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch(direction)
        {
            case 0:
                // Walking to the right
                directionVector = Vector3.right;
                break;
            case 1:
                // Walking up
                directionVector = Vector3.up;
                break;
            case 2:
                // Walking Left
                directionVector = Vector3.left;
                break;
            case 3:
                // Walking down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("Horizontal", directionVector.x);
        anim.SetFloat("Vertical", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetBool("Stopped", true);
        stopped = true;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Stopped", false);
        stopped = false;
    }


    void RandomStop()
    {
        float randomTime = Random.Range(1f, 3f);

        anim.SetBool("Stopped", true);

        Invoke("RandomStop", randomTime);
        //anim.SetBool("Stopped", false);

    }

    void RandomGo()
    {
        float randomTime = Random.Range(1f, 3f);

        if(!stopped)
        anim.SetBool("Stopped", false);

        Invoke("RandomGo", randomTime);
        //anim.SetBool("Stopped", false);

    }

}
