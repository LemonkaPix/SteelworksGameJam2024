using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    [SerializeField] GameObject interactTooltip;
    [SerializeField] TMP_Text tooltipText;
    [SerializeField] Material outlineMat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        MeshRenderer meshRenderer = transform.parent.GetComponent<MeshRenderer>();
        interactTooltip.SetActive(true);
        List<Material> mats = meshRenderer.materials.ToList();
        mats.Add(outlineMat);
        meshRenderer.SetMaterials(mats);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        interactTooltip.SetActive(false);


        MeshRenderer meshRenderer = transform.parent.GetComponent<MeshRenderer>();
        List<Material> mats = meshRenderer.materials.ToList();
        mats.RemoveAt(mats.Count - 1);
        meshRenderer.SetMaterials(mats);
    }
}
