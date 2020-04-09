using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerBubble : MonoBehaviour
{
    [SerializeField] Transform TeleportTo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = TeleportTo.position;
           

        }
    }

}
