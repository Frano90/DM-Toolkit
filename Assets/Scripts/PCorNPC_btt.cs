using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCorNPC_btt : MonoBehaviour
{
    [SerializeField] private Text buttonText;
    private Button button;

    private bool isPC;

    private void Start()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(ChangeBoolean);
    }

    private void ChangeBoolean()
    {
        isPC = !isPC;
    }

    public bool IsPCThisCharacter()
    {
        return isPC;
    }

    void Update()
    {
        if (isPC)
        {
            buttonText.text = "PC";
        }
        else
        {
            buttonText.text = "NPC";
        }
    }
}
