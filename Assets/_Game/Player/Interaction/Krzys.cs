using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krzys : MonoBehaviour
{
    [SerializeField] ItemObject neededItem;
    [SerializeField] ItemObject sodaItem;
    [SerializeField] string interactNewText;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] AudioSource explosionAudioSource;
    [SerializeField] GameObject objeectToDestroy;
    private void Start()
    {
        InventoryManager mng = PlayerManager.instance.GetComponent<InventoryManager>();
        mng.onInventoryChange += OnInventory;
    }
    public void OnInventory(ItemObject item, bool state)
    {
        if(item == neededItem)
        {
            GetComponent<TooltipTrigger>().tooltipCustomText = interactNewText;
        }
    }

    public void OnInteract()
    {
        InventoryManager mng = PlayerManager.instance.GetComponent<InventoryManager>();
        if (mng.items.Contains(neededItem))
        {
            mng.items.Remove(neededItem);
            explosionParticle.Play();
            explosionAudioSource.Play();
            StartCoroutine(WaitForEnd());
        }
        else
        {
            // Destroy(objeectToDestroy);
            // mng.AddItem(sodaItem);
        }
    }


    IEnumerator WaitForEnd()
    {
        yield return new WaitUntil(() => explosionAudioSource.isPlaying == false);
        Destroy(objeectToDestroy);
    }
}
