using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;

    public Image icon;
    public Button removeButton;
    public Sprite tempSprite;
    public Text counterText;

    public void AddItem (Item newItem)
    {
        item = newItem;
        tempSprite = Resources.Load<Sprite>("ItemSprites/" + item.name);
        icon.sprite = tempSprite;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void onRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void UpdateText()
    {
        if (item != null && item.isStackable)
        {
            Debug.Log(item.stackCount);
            counterText.text = item.stackCount + " / " + item.maxStack;
            counterText.enabled = true;
            if (item.stackCount == item.maxStack)
                counterText.enabled = false;
        }
        else
        {
            counterText.enabled = false;
        }
    }
}
