using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

}
