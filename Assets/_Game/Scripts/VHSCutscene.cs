using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class VHSCutscene : MonoBehaviour
{
    [SerializeField] Animator wall;
    // [SerializeField] Animator jigsaw;
    [SerializeField] private Transform sitTrans;
    [SerializeField] private GameObject firstSaws;
    [SerializeField] private GameObject lasers;

    private void Start()
    {
        StartCoroutine(Cutscene());
    }

    [Button]
    public IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerManager.instance.gameObject.transform.position = sitTrans.position;
        PlayerManager.CanMove = false;
        StartCoroutine(animation());
    }

    IEnumerator animation()
    {
        yield return new WaitForSeconds(1.9f);
        // jigsaw.SetInteger("phase", 1);
        // yield return new WaitForSeconds(2);
        HideWall();
        // jigsaw.SetInteger("phase", 2);
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
