using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VHSInteraction : MonoBehaviour
{
    [SerializeField] ItemObject neededItem;
    [SerializeField] ItemObject itemForEnable;
    [SerializeField] GameObject trigger;
    [SerializeField] Animator camAnim;
    [SerializeField] GameObject tv;
    [SerializeField] Material tvMat;
    [SerializeField] VideoPlayer videoPlr;
    [SerializeField] [Scene] int scene;

    void Start()
    {
        InventoryManager mng = PlayerManager.instance.GetComponent<InventoryManager>();
        mng.onInventoryChange += OnItem;
    }

    public void OnItem(ItemObject item, bool state)
    {
        Debug.Log(item);
        if(state == false && item == itemForEnable)
        {
            trigger.SetActive(true);
        }
    }

    public void OnInteract()
    {
        camAnim.gameObject.SetActive(true);
        Camera.main.gameObject.SetActive(false);

        camAnim.Play("StartCasette");
        tv.GetComponent<MeshRenderer>().material = tvMat;
        videoPlr.Play();
        StartCoroutine(waitForAnimEnd());
    }

    IEnumerator waitForAnimEnd()
    {
        yield return new WaitUntil(() => camAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1);
        SceneManager.LoadScene(scene);
    }
}
