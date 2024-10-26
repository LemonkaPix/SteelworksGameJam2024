using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    private bool moving = false;
    [SerializeField] private float speed = 7;
    [SerializeField] private float movingTime = 10;
    [SerializeField] private float lifeTime = 10;
    private bool canMove = true;
    public void Move()
    {
        moving = true;
        StartCoroutine(killer());
        StartCoroutine(stopper());
    }

    private void Update()
    {
        if (moving && canMove)
        {
            transform.position += transform.forward * (Time.deltaTime * speed);
        }
    }

    IEnumerator killer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    IEnumerator stopper()
    {
        yield return new WaitForSeconds(movingTime);
         canMove = false;

    }
}
