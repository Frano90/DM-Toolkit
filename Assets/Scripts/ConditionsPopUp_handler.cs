using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionsPopUp_handler : MonoBehaviour
{
    [SerializeField] private Button closePanel_btt;
    [SerializeField] private Button addDuration_btt;
    [SerializeField] private Button minusDuration_btt;

    [SerializeField] private Text duration_txt;
    private int duration = 10;
    
    [SerializeField] private Transform conditionSlotParent;
    
    
    public BattleEntity currentEntity { get; private set; }

    private void Start()
    {
        closePanel_btt.onClick.AddListener(ClosePanel);
        addDuration_btt.onClick.AddListener(AddDurationAmount);
        minusDuration_btt.onClick.AddListener(MinusDurationAmount);
        
        
        foreach (Transform slot in conditionSlotParent)
        {
            ConditionSlot condSlot = slot.GetComponent<ConditionSlot>();
            if(condSlot != null)
                condSlot.OnPressedButonSendCondition += ProcessCondition;
        }
    }

    private void Update()
    {
        duration_txt.text = duration.ToString();
    }

    private void AddDurationAmount()
    {
        duration++;
    }
    
    private void MinusDurationAmount()
    {
        duration--;
        if (duration < 0)
            duration = 0;
    }
    

    public void SetCurrentBattleEntity(BattleEntity ent)
    {
        currentEntity = ent;
    }
    

    private void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    private void ProcessCondition(Conditions condition)
    {
        ConditionDATA newCondData = new ConditionDATA();
        newCondData.condition = condition;
        newCondData.turnDuration = duration; 
        currentEntity.AddNewCondition(newCondData);
        currentEntity = null;
        ClosePanel();
    }
}
