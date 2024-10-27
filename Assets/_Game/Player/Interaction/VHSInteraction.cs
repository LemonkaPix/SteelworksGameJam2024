using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHSInteraction : MonoBehaviour
{
    [SerializeField] ItemObject neededItem;
    [SerializeField] ItemObject itemForEnable;

    [SerializeField] GameObject trigger;

    void Start()
    {

        InventoryManager mng = PlayerManager.instance.GetComponent<InventoryManager>();
        mng.onInventoryChange += OnItem;
    }

    public void OnItem(ItemObject item, bool state)
    {
        if(state == false && item == itemForEnable)
        {
            trigger.SetActive(true);
        }
    }
}
