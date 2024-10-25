using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent onInteract;
    [SerializeField] [TextArea(2, 5)] string customTooltip;
    public void OnInteract()
    {
        onInteract.Invoke();
    }

    public void ShowTooltip()
    {
        Debug.Log("enable");
        //PlayerManager.instance.ShowTooltip( customTooltip);
    }
}
