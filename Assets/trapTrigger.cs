using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapTrigger : MonoBehaviour
{
    [SerializeField] private MovingTrap trap;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 7)
        {
            
            trap.Move();
        }
    }
}
