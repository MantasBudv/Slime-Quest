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

    const int NumberOfTransf = 3;
    static public bool[] Transformations = new bool[NumberOfTransf];
    // 0 - slime
    // 1 - Mole(bear)
    // 2 - wolf
    static public int CurrentForm;
    Color SlimePink = new Color(255, 0, 77, 255);
    Color Default = new Color(255, 255, 255, 255);


    float[] slimeOff = new float[] { 0, 0, 0.83f, 0.71f };
    float[] wolfOff = new float[] { 0, -0.328f, 0.71f, 0.552f };
    float[] moleOff = new float[] { 0, -0.368f, 0.8f, 0.56f };
    List<float[]> offset = new List<float[]>();

    private void Start()
    {
        Animator = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
        Transformations[0] = true;
        offset.Add(slimeOff);
        offset.Add(moleOff);
        offset.Add(wolfOff);
    }


    // Update is called once per frame
    void Update()
    {
        if ((!newScene.Equals(SceneManager.GetActiveScene())) || (SaveManager.hasLoaded))
        {
            newScene = SceneManager.GetActiveScene();
            Shapeshift(CurrentForm, offset[CurrentForm]);

        }

        if ((Input.GetButtonDown("Trans1")) && (Time.time > NextTrans))
        {
            NextTrans = Time.time + TransRate;
            Shapeshift(0, offset[0]);

        }
        if ((Input.GetButtonDown("Trans2")) && (Time.time > NextTrans)) 
        {
            NextTrans = Time.time + TransRate;
            Shapeshift(1, offset[1]);

        }
        if ((Input.GetButtonDown("Trans3")) && (Time.time > NextTrans))
        {
            NextTrans = Time.time + TransRate;

            Shapeshift(2, offset[2]);

        }
    }

    public void Shapeshift(int form, float[] offset)
    {
        if (Transformations[form])
        {
            if(Animator.GetInteger("Form") != form)
            {
                Animator.SetInteger("Form", form);
                CurrentForm = form;
                if (form != 0)
                    Renderer.color = SlimePink;
                else Renderer.color = Default;
                gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(offset[0], offset[1]);
                gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(offset[2], offset[3]);
                if (form == 2)
                    PlayerMovement.moveSpeed = 8f;
            }
        }
    }
}
