using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    [SerializeField] float attackTime;
    [SerializeField] float speed;
    public bool isAttacking = false;
    Vector3 startingPos;

    [Button]
    public void StartAttack()
    {
        startingPos = transform.position;
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        isAttacking = true;
        Invoke(nameof(StopAttack), attackTime);
    }

    public void StopAttack()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = startingPos;
        isAttacking = false;
    }

}
