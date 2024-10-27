using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUINav : MonoBehaviour
{
    [SerializeField] Vector3 resizeFrom;
    [SerializeField] Vector3 resizeTo;
    [SerializeField] Camera cam;
    [SerializeField] MeshRenderer tv;
    [SerializeField] Material tvMat;
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

    public void StartGame()
    {
        cam.GetComponent<Animator>().Play("MainMenu");
        tv.material = tvMat;
        StartCoroutine(WaitForCam());
    }

    IEnumerator WaitForCam()
    {
        yield return new WaitUntil(() => cam.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !cam.GetComponent<Animator>().IsInTransition(0));
        SceneManager.LoadScene(1);
    }
}
