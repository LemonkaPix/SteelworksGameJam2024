using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAttack : MonoBehaviour
{
    [SerializeField] float attackTime;
    [SerializeField] float speed;
    public bool isAttacking = false;
    Vector3 startingPos;
    [SerializeField] List<GameObject> saws;
    [SerializeField] List<GameObject> lasers;
    [SerializeField] int numberOfSawsGone;
    [Button]
    public void StartAttack()
    {

        foreach (GameObject obj in saws)
        {
            obj.SetActive(true);
        }

        foreach(GameObject obj in lasers)
        { obj.SetActive(true); }

        int range = Random.Range(0, saws.Count);

        saws[range].SetActive(false);
        if(range +1 < saws.Count)  saws[range +1].SetActive(false);
        if(range -1 > -1) saws[range - 1].SetActive(false);


        startingPos = transform.position;
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        isAttacking = true;
        Invoke(nameof(StopAttack), attackTime);
    }

    public void StopAttack()
    {
        foreach (GameObject obj in saws)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in lasers)
        { obj.SetActive(false); }


        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = startingPos;
        isAttacking = false;
    }
}
