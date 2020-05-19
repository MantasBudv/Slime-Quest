using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory is found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public static int space = 12;

    public static List<Item> items = new List<Item>();

    private static Scene newScene;

    void Update()
    {
        if (onItemChangedCallback != null && !newScene.Equals(SceneManager.GetActiveScene()))
        {
            newScene = SceneManager.GetActiveScene();
            onItemChangedCallback.Invoke();
        }
    }
    public bool Add (Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("No room in inventory.");
            return false;
        }
        if (item.isStackable)
        {
            bool isNew = true;
            items.ForEach(i => { if (i.name == "Goo") isNew = false; });

            if (isNew)
            {
                item.stackCount = 0;
            }

            if (item.stackCount != item.maxStack)
            {
                if (isNew)
                {
                    item.stackCount++;
                    items.Add(item);
                }
                else
                {
                    items.ForEach(i => { if (i.name == "Goo") { i.stackCount++; } });
                }
            }
        } 
        else items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove (Item item)
    {
        if (item.isStackable)
            item.stackCount = 0;
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public void SetItems(List<Item> ITEMS)
    {
        items = ITEMS;
    }
}
