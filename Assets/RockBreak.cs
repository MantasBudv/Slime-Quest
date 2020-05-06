using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : MonoBehaviour
{
    bool PlayerInRange = false;
    public virtual void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && (PlayerInRange) && (Shapeshifting.CurrentForm == 1))
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }

}
