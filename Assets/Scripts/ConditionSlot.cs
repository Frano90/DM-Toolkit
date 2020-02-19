using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionSlot : MonoBehaviour
{
    public Conditions condition;
    private Button thisButton;

    public event Action<Conditions> OnPressedButonSendCondition = delegate { };

    private void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(PressedButton);
    }

    private void PressedButton()
    {
        OnPressedButonSendCondition(condition);
    }
}
