using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // public static bool locked = false;
    public Transform cameraPosition;

    private void Update()
    {
        // if(!PlayerManager.CameraLocked)
            transform.position = cameraPosition.position;
    }
}
