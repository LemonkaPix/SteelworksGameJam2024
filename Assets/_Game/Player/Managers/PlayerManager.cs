using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;
    public static bool CanMove = true;

    
    
    private void Awake()
    { 
        Time.timeScale = 1;
        if (instance == null)
            instance = this;
    }

}
