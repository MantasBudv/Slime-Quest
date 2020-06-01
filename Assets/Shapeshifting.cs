﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shapeshifting : MonoBehaviour
{
    Animator Animator;
    SpriteRenderer Renderer;
    private static Scene newScene;

    float TransRate = 1f;
    float NextTrans;

    const int NumberOfTransf = 3;
    static public bool[] Transformations = new bool[NumberOfTransf];
    // 0 - slime
    // 1 - Mole(bear)
    // 2 - wolf
    static public int CurrentForm;
    Color SlimePink = new Color(255, 0, 77, 255);
    Color Default = new Color(255, 255, 255, 255);

    private void Start()
    {
        Animator = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
        Transformations[0] = true;
    }


    // Update is called once per frame
    void Update()
    {
        if ((!newScene.Equals(SceneManager.GetActiveScene())) || (SaveManager.hasLoaded))
        {
            newScene = SceneManager.GetActiveScene();
            if (CurrentForm != 0)
            {
                Animator.SetInteger("Form", CurrentForm);
                Renderer.color = SlimePink;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

        }

        if ((Input.GetKeyDown(KeyCode.O)) && (Time.time > NextTrans)) 
        {
            NextTrans = Time.time + TransRate;
            Shapeshift(1);

        }
        if ((Input.GetKeyDown(KeyCode.Y)) && (Time.time > NextTrans))
        {
            NextTrans = Time.time + TransRate;

            Shapeshift(2);

        }
    }

    public void Shapeshift(int form)
    {
        if (Transformations[form])
        {
            if(Animator.GetInteger("Form") != form)
            {
                Animator.SetInteger("Form", form);
                CurrentForm = form;
                Renderer.color = SlimePink;
                //cap collider offset/size array
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                if (form == 2)
                    PlayerMovement.moveSpeed = 8f;
            }
            else
            {
                Animator.SetInteger("Form", 0);
                CurrentForm = 0;
                Renderer.color = Default;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                PlayerMovement.moveSpeed = 6f;
            }
        }
    }
}
