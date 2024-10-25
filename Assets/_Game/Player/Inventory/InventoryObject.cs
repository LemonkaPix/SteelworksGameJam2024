using NaughtyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Inventory", order = -100)]
public class InventoryObject : ScriptableObject
{
    [SerializeField] List<InventoryItem> inventoryItems;
    [field: SerializeField]
    public int Size { get; private set; } = 35;

    [field: SerializeField]
    public bool Initialized { get; private set; } = false;

    [Button("Reset Inventory")]
    public void Initialize()
    {
        if (Initialized) return;
        inventoryItems = new List<InventoryItem>();
        for(int i = 0; i < Size; i++)
        {
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
        Initialized = true;
    }

    public bool AddItem(ItemObject item, int amount = 1)
    {

        if (!item.CanStack) amount = 1;
        else
        {
            if(amount > item.MaxStack) amount = item.MaxStack;
        }

        if(inventoryItems.Any(x => x.item == item))
        {   
            int indexOfItem = inventoryItems.FindIndex(x => x.item == item && x.amount < item.MaxStack);


            if(indexOfItem != -1)
            {
                if (inventoryItems[indexOfItem].item.CanStack)
                    AddItemAmount(indexOfItem, amount);

                return true;
            }
        }


        for (int i = 0; i < inventoryItems.Count;i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                inventoryItems[i] = new InventoryItem() { item = item, amount = amount } ;
                return true;
            }
        }

        return false;
    }

    void RemoveItemAmount(int itemIndex, int amount)
    {
        InventoryItem item = inventoryItems[itemIndex];
        int newAmount = item.amount - amount;

        if (newAmount < 0) RemoveItem(itemIndex);
        else inventoryItems[itemIndex] = item.ChangeAmount(newAmount);

    }

    void AddItemAmount(int itemIndex, int amount)
    {
        InventoryItem item = inventoryItems[itemIndex];

        if (!item.item.CanStack) return;
        
        int newAmount = item.amount + amount;

        if(newAmount > item.item.MaxStack) newAmount = item.item.MaxStack;

        inventoryItems[itemIndex] = item.ChangeAmount(newAmount);
    }


    public void RemoveItem(int itemIndex, int amount = 1)
    {

        if(amount > 1) RemoveItemAmount(itemIndex, amount);
        else inventoryItems.RemoveAt(itemIndex);
    }

    public void RemoveItem(InventoryItem item)
    {
        inventoryItems.Remove(item);
    }


    public Dictionary<int, InventoryItem> GetInventoryState()
    {
        Dictionary<int, InventoryItem> inventoryState = new Dictionary<int, InventoryItem>();

        for(int i = 0; i < inventoryItems.Count;i++)
        {
            if (inventoryItems[i].IsEmpty) continue;
            inventoryState[i] = inventoryItems[i];
        }
        return inventoryState;
    }

    public InventoryItem GetItem(int itemIndex)
    {
        return inventoryItems[itemIndex];
    }
}

[Serializable]
public struct InventoryItem
{
    public ItemObject item;
    public int amount;

    public ItemVariant itemVariant;

    public bool IsEmpty => item == null;

    public InventoryItem ChangeAmount(int newAmount)
    {
        return new InventoryItem
        {
            item = this.item,
            amount = newAmount,
        };
    }

    public static InventoryItem GetEmptyItem() => new InventoryItem
    {
        item = null,
        amount = 0,
    };

}