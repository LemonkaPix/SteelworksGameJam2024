using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public List<ItemObject> items;

    public int inventorySize;
   

    public void AddItem(ItemObject item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemObject item)
    {
        items.Remove(item);
    }
}
