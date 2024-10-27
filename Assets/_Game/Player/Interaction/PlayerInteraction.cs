using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] LayerMask interactionLayer;
    [SerializeField] KeyCode interactionButton;
    GameObject closestObject;

    [Header("Debug")]
    [SerializeField] bool drawGizmo;
    private void Update()
    {

        if(Input.GetKeyDown(interactionButton)) 
        {
            if(closestObject && closestObject.GetComponent<Interactable>().canBeInteracted)
                closestObject.GetComponent<Interactable>().OnInteract();
        }
    }

    private void FixedUpdate()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, radius, interactionLayer);

        float closestDistance = Mathf.Infinity;
        closestObject = null;

        foreach(Collider obj in nearbyObjects)
        {
            if (!obj.GetComponent<Interactable>()) continue;

            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj.gameObject;
            }
        }


    }

    private void OnDrawGizmos()
    {
        if (drawGizmo) 
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
