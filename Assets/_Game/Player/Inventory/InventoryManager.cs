using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InventoryChangeHandler(ItemObject item, bool added);
public class InventoryManager : MonoBehaviour
{

    public event InventoryChangeHandler onInventoryChange;


    public List<ItemObject> items;

    public int inventorySize;


    public void AddItem(ItemObject item)
    {
        items.Add(item);
        onInventoryChange?.Invoke(item, true);

    }


    public void RemoveItem(ItemObject item)
    {
        items.Remove(item);
        onInventoryChange.Invoke(item, false);

    }
}
