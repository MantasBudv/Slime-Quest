using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/WolfShard")]

[System.Serializable]
public class WolfShard : Item
{

    public override void Use()
    {

        Debug.Log(itemname + " " + stackCount + " " + maxStack);
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
