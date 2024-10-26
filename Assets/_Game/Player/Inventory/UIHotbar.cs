using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHotbar : MonoBehaviour
{
    [SerializeField] Image[] slots = new Image[4];

    void UpdateHotbar()
    {
        List<ItemObject> items = PlayerManager.instance.GetComponent<InventoryManager>().items;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i > items.Count - 1)
            {
                slots[i].sprite = null;
                slots[i].enabled = false;
            }
            else
            {
                ItemObject item = items[i];
                slots[i].enabled = true;
                slots[i].sprite = item.DefaultSprite;
            }
        }
    }

    public void Update()
    {
        UpdateHotbar();
    }
}
