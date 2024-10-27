using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // int a = 0;
    [SerializeField] bool onEnable = false;
    
    [SerializeField] private AudioSource source;

    private void OnEnable()
    {
        if(onEnable)
            source.Play();
    }

    public void PlaySource()
    {
        source.Play();
    }
}
