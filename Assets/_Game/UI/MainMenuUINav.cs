using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUINav : MonoBehaviour
{
    [SerializeField] Vector3 resizeFrom;
    [SerializeField] Vector3 resizeTo;
    bool resizingFinished = false;
    bool isResizing = false;

    public void OnHoverEnter(GameObject uiObj)
    {
        if(!isResizing)
        {
            resizingFinished = false;
            isResizing = true;
            uiObj.LeanScale(resizeTo, .1f).setOnComplete(() => { isResizing = false; resizingFinished = true; });
        }

    }

    public void OnHoverExit(GameObject uiObj)
    {
        if (!isResizing)
            uiObj.LeanScale(resizeFrom, .1f);
        else StartCoroutine(WaitForResize(uiObj));
    }


    IEnumerator WaitForResize(GameObject uiObj)
    {
        yield return new WaitUntil(() => resizingFinished);
        uiObj.LeanScale(resizeFrom, .1f);

    }

}
