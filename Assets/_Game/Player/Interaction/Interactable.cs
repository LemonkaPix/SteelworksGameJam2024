using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent onInteract;
    public void OnInteract()
    {
        onInteract.Invoke();
    }
}
