using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEntityCondition : MonoBehaviour
{
    [SerializeField] private Text conditionName_txt;
    [SerializeField] private Text conditionDuration_txt;
    public int conditionDuration { get; private set; }
    public Conditions condition { get; private set; }
    

    public void SetData(Conditions condition, int conditionDuration)
    {
        conditionName_txt.text = condition.ToString();
        this.condition = condition;
        this.conditionDuration = conditionDuration;
    }

    private void Update()
    {
        conditionDuration_txt.text = conditionDuration.ToString();
    }

    public int MinusOneTurnDuration()
    {
        conditionDuration--;
        
        if(conditionDuration <= 0)
            Destroy(gameObject.gameObject);
        
        return conditionDuration;
    }
}
