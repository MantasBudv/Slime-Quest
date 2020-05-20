using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/MoleShard")]

public class MoleShard : Item
{

    public override void Use()
    {
        if (stackCount == maxStack)
        {
            if (Shapeshifting.Transformations[1] != true && isUsed == false)
            {
                isUsed = true;
                Shapeshifting.Transformations[1] = true;
                Inventory.instance.Remove(this);
            }
        }


    }


}
