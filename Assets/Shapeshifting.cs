using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapeshifting : MonoBehaviour
{
    Animator Animator;
    SpriteRenderer Renderer;

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
        if(Input.GetKeyDown(KeyCode.O))
        {
            if (Transformations[1])
                if (Animator.GetInteger("Form") != 1)
                {
                    Animator.SetInteger("Form", 1);
                    CurrentForm = 1;
                    Renderer.color = SlimePink;
                }
                else
                {
                    Animator.SetInteger("Form", 0);
                    CurrentForm = 0;
                    Renderer.color = Default;
                }
        }
    }
}
