using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("picking up " + item.name);
            if (!item.isUsed)
            Inventory.instance.Add(item);
            
            Destroy(gameObject);
        }
    }
}
