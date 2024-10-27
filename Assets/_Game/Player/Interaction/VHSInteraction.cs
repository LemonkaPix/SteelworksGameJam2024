using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHSInteraction : MonoBehaviour
{
    [SerializeField] ItemObject neededItem;
    [SerializeField] ItemObject itemForEnable;
    private Animator animator;
    [SerializeField] GameObject trigger;

    void Start()
    {
        animator = GetComponent<Animator>();
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

    public void OnInteract()
    {
        animator.Play("casetaIn");
        //Do sth
        print("I do sth");
    }
}
