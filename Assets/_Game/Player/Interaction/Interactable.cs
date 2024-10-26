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
    [SerializeField] InteractionType interactionType;

    [ShowIf("interactionType", InteractionType.Pickup)]
    [SerializeField] ItemObject itemToGive;

    [ShowIf("interactionType", InteractionType.Use)]
    [SerializeField] UnityEvent onInteract;

    public void OnInteract()
    {
        onInteract.Invoke();

        if(itemToGive != null)
        {
            InventoryManager inventoryManager = PlayerManager.instance.GetComponent<InventoryManager>();

            inventoryManager.items.Add(itemToGive);
            TooltipTrigger trigger = GetComponentInChildren<TooltipTrigger>();
            trigger.HideTooltip();
            Destroy(gameObject);
        }
    }
}
