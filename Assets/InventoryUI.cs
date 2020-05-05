using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static bool InventoryIsOpen = false;

    public GameObject InventoryTab;

    Inventory inventory;

    public Transform itemsParent;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!InventoryIsOpen)
            {
                OpenInventory();
                InventoryIsOpen = true;
            }
            else
            {
                CloseInventory();
                InventoryIsOpen = false;
            }
        }
    }

    void OpenInventory()
    {
        InventoryTab.SetActive(true);
    }
    void CloseInventory()
    {
        InventoryTab.SetActive(false);
    }

    void UpdateUI ()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("Updated Items");
            if (i < inventory.GetItems().Count)
            {
                slots[i].AddItem(inventory.GetItems()[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
