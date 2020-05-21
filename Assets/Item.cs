﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isStackable = false;
    public int stackCount = 0;
    public int maxStack = 0;
    public bool isUsed = false;

    int healthIncrease = 1;

    // it was virtual
    public virtual void Use()
    {
        if (name == "Heart")
        {
            HeroHealth.maxHealth += 1;
            Inventory.instance.Remove(this);
        }
        if (name == "Goo" && stackCount == maxStack)
        {
            //if (Shapeshifting.Transformations[1] != true && isUsed == false)
            //{
            //    isUsed = true;
            //    Shapeshifting.Transformations[1] = true;
            //    Inventory.instance.Remove(this);
            //}
        }
        Debug.Log("Using " + name);
    }
}
