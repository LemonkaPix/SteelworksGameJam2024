using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    private bool moving = false;
    [SerializeField] private float speed = 7;
    [SerializeField] private float lifeTime = 10;
    public void Move()
    {
        moving = true;
        StartCoroutine(killer());
    }

    private void Update()
    {
        if (moving)
        {
            transform.position += transform.forward * (Time.deltaTime * speed);
        }
    }

    IEnumerator killer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
