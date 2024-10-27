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
    [SerializeField] private Transform p2Trans;
    [SerializeField] private GameObject firstSaws;
    [SerializeField] private GameObject lasers;
    [SerializeField] private GameObject traps1;
    [SerializeField] private GameObject traps2;

    private void Start()
    {
        StartCoroutine(Cutscene());
    }

    [Button]
    public IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(0.1f);
        if (PlayerPrefs.GetInt("phase") == 2)
        {
            PlayerManager.instance.gameObject.transform.position = p2Trans.position;

            print("widze p2");
            p2();
        }
        else if(PlayerPrefs.GetInt("phase") == 0)
        {
            
            PlayerManager.instance.gameObject.transform.position = sitTrans.position;

        }

        if (PlayerPrefs.GetInt("phase") == 0)
        {
            PlayerManager.CanMove = false;
            StartCoroutine(animation());
        }
        

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

    [Button]
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void p2()
    {
        print($"{PlayerPrefs.GetInt("phase")} JEST TU FAZA 2");
        PlayerPrefs.SetInt("phase", 2);

        traps1.SetActive(false);
        traps2.SetActive(true);
        lasers.SetActive(false);
    }
}
