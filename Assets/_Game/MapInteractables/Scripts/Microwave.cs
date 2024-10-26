using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Microwave : MonoBehaviour
{
    [SerializeField] ItemObject itemNeeded;
    [SerializeField] ItemObject itemToGive;
    [SerializeField] float waitTime;
    [SerializeField] Material outlineShader;

    bool itemReady = false;
    public void OnInteract()
    {
        InventoryManager inventoryManager = PlayerManager.instance.GetComponent<InventoryManager>();

        if (itemReady)
        {
            inventoryManager.AddItem(itemToGive);
            itemReady = false;
            TooltipTrigger trigger = GetComponentInChildren<TooltipTrigger>();
            trigger.HideTooltip();
            Destroy(gameObject);
        }
        else
        {
            if (!inventoryManager.items.Contains(itemNeeded)) return;
            inventoryManager.items.Remove(itemNeeded);
            StartCoroutine(enumerator());

        }

    }

    IEnumerator enumerator()
    {
        TooltipTrigger trigger = GetComponentInChildren<TooltipTrigger>();

        if (trigger) trigger.HideTooltip();

        GetComponent<Interactable>().canBeHighlighted = false;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        
        List<Material> mats = meshRenderer.materials.ToList();

        mats.Add(outlineShader);
        meshRenderer.SetMaterials(mats); float elapsedTime = 0;
        while (elapsedTime < waitTime)
        {
            elapsedTime += .1f;
            meshRenderer.materials[1].color = Color.Lerp(Color.red, Color.green, elapsedTime / waitTime);
            yield return new WaitForSeconds(.1f);
        }

        mats = meshRenderer.materials.ToList();
        mats.RemoveAt(mats.Count - 1);
        meshRenderer.SetMaterials(mats);

        GetComponent<Interactable>().canBeHighlighted = true;

        float distance = Vector3.Distance(PlayerManager.instance.transform.position, transform.position);
        if (trigger && distance < 3.5) trigger.ShowTooltip();
        itemReady = true;
    }

}
