using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerSwitch : MonoBehaviour
{
    public static bool state = false;
    bool PlayerInRange;

    [SerializeField]
    Sprite altSprite;


    private void Start()
    {
        if (state)
            gameObject.GetComponent<SpriteRenderer>().sprite = altSprite;
    }

    public virtual void Update()
    {
        if (Input.GetButtonDown("Interact") && PlayerInRange)
        {
            state = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = altSprite;
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }

}
