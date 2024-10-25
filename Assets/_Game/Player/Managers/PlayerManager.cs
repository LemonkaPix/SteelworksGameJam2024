using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;

    [SerializeField] GameObject tooltipPanel;
    private void Start()
    {
        tooltipPanel.SetActive(false);
    }
    private void Awake()
    {
        instance = this;
    }

}
