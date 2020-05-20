using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooScript : MonoBehaviour
{
    public int TranformIndex;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //if (Shapeshifting.Transformations[TranformIndex] != true)
            //Shapeshifting.Transformations[TranformIndex] = true;
        }
    }
}
