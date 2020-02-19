using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BattleEntity))]
public class Condition_handler : MonoBehaviour
{
    [SerializeField] private Transform conditionsParent;
    [SerializeField] private BattleEntityCondition _conditionSlot_prefab;
    private List<BattleEntityCondition> currentConditionsOnEntity = new List<BattleEntityCondition>();

    private BattleEntity entity;

    private void Start()
    {
        entity = GetComponent<BattleEntity>();
    }

    public void PopulateConditions()
    {
        foreach (ConditionDATA condition in entity.conditions)
        {
            BattleEntityCondition newSlot = Instantiate<BattleEntityCondition>(_conditionSlot_prefab, conditionsParent);
            
            newSlot.SetData(condition.condition, condition.turnDuration);
            
            currentConditionsOnEntity.Add(newSlot);
        }
        
        entity.conditions.Clear();
    }

    public void PassOneTurn()
    {
        for (int i = currentConditionsOnEntity.Count - 1; i >= 0; i--)
        {

            if (currentConditionsOnEntity[i].MinusOneTurnDuration() <= 0)
            {
                for (int j = 0; j < entity.conditions.Count; j++)
                {
                    if (entity.conditions[j].condition == currentConditionsOnEntity[i].condition)
                    {
                        entity.conditions.RemoveAt(j);
                    }
                    
                }
                currentConditionsOnEntity.RemoveAt(i);
            }
        }
        
    }
    
}
