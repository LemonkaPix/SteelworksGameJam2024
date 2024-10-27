using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public enum InteractionType
{
    Pickup,
    Use
}


[RequireComponent(typeof(BoxCollider))]

public class Interactable : MonoBehaviour
{

    public bool canBeHighlighted = true;
    public bool canBeInteracted = true;
    [SerializeField] InteractionType interactionType;

    [ShowIf("interactionType", InteractionType.Pickup)]
    [SerializeField] ItemObject itemToGive;

    [ShowIf("interactionType", InteractionType.Use)]
    [SerializeField] ItemObject checkForItem;

    [SerializeField] UnityEvent onInteract;

    [SerializeField] GameObject objectToDestroy;

    private void Start()
    {
        if(checkForItem)
        {
            InventoryManager mng = PlayerManager.instance.GetComponent<InventoryManager>();
            mng.onInventoryChange += CheckForItem;
        }
    }

    public void CheckForItem(ItemObject item, bool state)
    {
        if(checkForItem == item)
        {
            canBeHighlighted = true;
            canBeInteracted = true;
            TooltipTrigger trigger = GetComponentInChildren<TooltipTrigger>();

            trigger.ShowTooltip();
        }
    }

    public void OnInteract()
    {
        onInteract.Invoke(); 

        if(itemToGive != null)
        {
            InventoryManager inventoryManager = PlayerManager.instance.GetComponent<InventoryManager>();

            if (itemToGive)
            {
                inventoryManager.AddItem(itemToGive);
                Destroy(objectToDestroy);
            }
            TooltipTrigger trigger = GetComponentInChildren<TooltipTrigger>();
            trigger.HideTooltip();
            if(objectToDestroy) Destroy(objectToDestroy);
        }
    }
}
