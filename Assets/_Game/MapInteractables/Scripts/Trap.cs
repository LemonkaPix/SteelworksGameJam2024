using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] bool triggered;
    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        Debug.Log("Player touch trap");
        triggered = true;
    }
}
