using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

[System.Serializable]
[XmlInclude(typeof(WolfShard))]
[XmlInclude(typeof(MoleShard))]
public class Item : ScriptableObject
{
    new public string name = "New Item";

    public bool isStackable = false;
    public int stackCount = 0;
    public int maxStack = 0;
    public bool isUsed = false;


    // it was virtual
    public virtual void Use()
    {
        if (name == "Heart")
        {
            HeroHealth.maxHealth += 1;
            Inventory.instance.Remove(this);
        }
        Debug.Log("Using " + name);
    }
}
