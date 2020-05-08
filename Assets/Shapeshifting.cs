using System.Collections;
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

    const int NumberOfTransf = 2;
    static public bool[] Transformations = new bool[NumberOfTransf];
    // 0 - slime
    // 1 - Mole(bear)
    static public int CurrentForm;
    Color SlimePink = new Color(255, 0, 77, 255);
    Color Default = new Color(255, 255, 255, 255);

    private void Start()
    {
        Animator = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!newScene.Equals(SceneManager.GetActiveScene()))   
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

            if (Transformations[1])                         //Check if mole/bear form is acquired
                if (Animator.GetInteger("Form") != 1)       //If player is not in bear/mole form - switch
                {
                    Animator.SetInteger("Form", 1);
                    CurrentForm = 1;
                    Renderer.color = SlimePink;
                    gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                    gameObject.GetComponent<BoxCollider2D>().enabled = true;
                }
                else
                {
                    Animator.SetInteger("Form", 0);
                    CurrentForm = 0;
                    Renderer.color = Default;
                    gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
        }
    }
}
