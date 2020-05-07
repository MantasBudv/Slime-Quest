﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isStackable = false;
    public int stackCount = 0;
    public int maxStack = 0;

    public virtual void Use()
    {
        if (name == "Heart")
        {
            //HealthBar
        }
        Debug.Log("Using " + name);
    }
}
