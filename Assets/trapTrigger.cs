using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trapTrigger : MonoBehaviour
{
    [SerializeField] private MovingTrap[] trap;
    [SerializeField] private float delay = 0f;
    public UnityEvent onEvent;
    private void OnTriggerEnter(Collider other)
    {
        onEvent.Invoke();
        if (other.gameObject.layer == 7)
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        foreach (var t in trap)
        {
            t.Move();
            yield return new WaitForSeconds(delay);
        }

    }
}
