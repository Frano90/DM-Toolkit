using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BattleEntity : MonoBehaviour
{
    [SerializeField] private Text charName_txt;
    [SerializeField] private Text currentHP_txt;
    [SerializeField] private Text initRoll_txt;

    [SerializeField] private Button addHp_btt;
    [SerializeField] private Button restHp_btt;
    [SerializeField] private Button addCondition_btt;
    [SerializeField] private Button delete_btt;

    public event Action<BattleEntity> onPressedConditionPanelToggle = delegate { };
    public event Action<BattleEntity> onPressedDelete = delegate { };

    private Condition_handler _conditionHandler;

    public int initRoll { get; private set; }
    public int initMod { get; private set; }
    public int currentHp { get; private set; }
    public int maxHp { get; private set; }
    
    public List<ConditionDATA> conditions { get; private set; }
    
    public int battleID { get; private set; }
    public string characterName { get; private set; }

    #region Init Settings


    public void EntityTurnBegin()
    {
        _conditionHandler.PassOneTurn();
    }
    
    public void SetData(int hp, string entityName, int iniciativeMod, int id)
    {
        battleID = id;
        characterName = entityName;
        maxHp = hp;
        currentHp = hp;
        initMod = iniciativeMod;
    }

    public void SetInit(int init)
    {
        initRoll = init;
        initRoll_txt.text = init.ToString();
    }

    private void Start()
    {
        addHp_btt.onClick.AddListener(AddHp);
        restHp_btt.onClick.AddListener(MinusHp);
        addCondition_btt.onClick.AddListener(PressedConditionPanel_btt);
        delete_btt.onClick.AddListener(PressedDelete);
        _conditionHandler = GetComponent<Condition_handler>();
        conditions = new List<ConditionDATA>();
    }

    #endregion

    private void Update()
    {
        charName_txt.text = characterName;
        currentHP_txt.text = currentHp.ToString();
    }
    
    private void SetHpToMax()
    {
        currentHp = maxHp;
    }

    private void PressedConditionPanel_btt()
    {
        onPressedConditionPanelToggle(this);
    }
    
    private void PressedDelete()
    {
        onPressedDelete(this);
    }
    
    
    private void AddHp()
    {
        currentHp += 1;
    }
    
    private void MinusHp()
    {
        currentHp -= 1;
    }

    public void AddNewCondition(ConditionDATA newCondition)
    {
        conditions.Add(newCondition);   
        _conditionHandler.PopulateConditions();
    }

}
