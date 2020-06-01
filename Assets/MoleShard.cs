using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/MoleShard")]

[System.Serializable]
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
