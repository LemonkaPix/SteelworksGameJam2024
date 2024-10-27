using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    [SerializeField] ItemObject neededItem;
    [SerializeField] GameObject screenFade;

    [SerializeField] Transform teleportLocation;
    void Start()
    {
        InventoryManager mng = PlayerManager.instance.GetComponent<InventoryManager>();
        mng.onInventoryChange += InventoryChangeHandler;
    }

    void InventoryChangeHandler(ItemObject item, bool state)
    {

        if (state == true && item == neededItem)
        {
            Interactable interactable = GetComponent<Interactable>();
           interactable.canBeHighlighted = true;
            interactable.canBeInteracted = true;
        }
    }

    public void OnInteract()
    {
        screenFade.LeanScale(new Vector3(100, 100, 100), .5f).setOnComplete(() =>
        {
            PlayerManager.instance.transform.position = teleportLocation.position;
            screenFade.LeanScale(Vector3.zero, .5f);
        });
    }
}
