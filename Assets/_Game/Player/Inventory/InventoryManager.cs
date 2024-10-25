using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [Expandable] [SerializeField] InventoryObject inventoryData;

    public int inventorySize;

    // Start is called before the first frame update
    void Start()
    {
        inventoryData.Initialize();
    }

    public InventoryObject GetInventory()
    {
        return inventoryData;
    }

    public InventoryItem GetItem(int itemIndex)
    {
        return inventoryData.GetItem(itemIndex);
    }

    public bool AddItem(ItemObject item, int amount = 1)
    {
        bool result = inventoryData.AddItem(item, amount);

        if(result == false)
        {
            Debug.Log("Inv full");
        }

        return result;
    }


    public void RemoveItem(int itemIndex)
    {
        inventoryData.RemoveItem(itemIndex);
    }

    public void RemoveItem(InventoryItem item)
    {
        inventoryData.RemoveItem(item);
    }
}
