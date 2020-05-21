using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/WolfShard")]

public class WolfShard : Item
{


    public override void Use()
    {
        if (stackCount == maxStack)
        {
            if (Shapeshifting.Transformations[2] != true && isUsed == false)
            {
                isUsed = true;
                Shapeshifting.Transformations[2] = true;
                Inventory.instance.Remove(this);
            }
        }


    }


}
