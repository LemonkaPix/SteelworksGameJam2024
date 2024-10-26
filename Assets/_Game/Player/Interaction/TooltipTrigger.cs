using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    [SerializeField] GameObject interactTooltip;
    [SerializeField] TMP_Text tooltipText;
    [SerializeField][TextArea] string tooltipCustomText;
    [SerializeField] Material outlineMat;

    public void ShowTooltip()
    {
        interactTooltip.GetComponent<CanvasGroup>().alpha = 1;
        tooltipText.text = tooltipCustomText;
        if (transform.parent.GetComponent<Interactable>().canBeHighlighted)
        {


            MeshRenderer meshRenderer = transform.parent.GetComponent<MeshRenderer>();

            List<Material> mats = meshRenderer.materials.ToList();
            mats.Add(outlineMat);
            meshRenderer.SetMaterials(mats);
        }
    }

    public void HideTooltip()
    {
        interactTooltip.GetComponent<CanvasGroup>().alpha = 0;
        if (transform.parent.GetComponent<Interactable>().canBeHighlighted)
        {


            MeshRenderer meshRenderer = transform.parent.GetComponent<MeshRenderer>();
            List<Material> mats = meshRenderer.materials.ToList();
            mats.RemoveAt(mats.Count - 1);
            meshRenderer.SetMaterials(mats);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 7) return;


        ShowTooltip();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;

        HideTooltip();
    }
}
