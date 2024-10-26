using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class VHSCutscene : MonoBehaviour
{
    [SerializeField] Animator wall;
    [SerializeField] Animator jigsaw;
    [SerializeField] private Transform sitTrans;
    [SerializeField] private GameObject firstSaws;
    [SerializeField] private GameObject lasers;
    
    [Button]
    public void Cutscene()
    {
        PlayerManager.instance.gameObject.transform.position = sitTrans.position;
        PlayerManager.CanMove = false;
        StartCoroutine(animation());
    }

    IEnumerator animation()
    {
        yield return new WaitForSeconds(2);
        jigsaw.SetInteger("phase", 1);
        yield return new WaitForSeconds(2);
        HideWall();
        jigsaw.SetInteger("phase", 2);
        firstSaws.SetActive(true);
        lasers.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        CanMoveTrue();

    }

    [Button]
    public void HideWall()
    {
        wall.Play("WallZiup");
    }
    [Button]
    public void CanMoveTrue()
    {
        PlayerManager.CanMove = true;

    }
}
