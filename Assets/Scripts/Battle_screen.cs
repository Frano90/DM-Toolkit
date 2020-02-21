using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Battle_screen : Screen
{
    [SerializeField] private Transform characterParent;
    [SerializeField] private Transform characterParent_aux;
    
    [SerializeField] private BattleEntity entity_prefab;

    [SerializeField] private Button backToMainMenu_btt;
    [SerializeField] private Button reroll_btt;
    [SerializeField] private Button passTurn_btt;

    [SerializeField] private ConditionsPopUp_handler conditionPanel;

    [SerializeField] private Text turns_counter;
    public int turnCounter { get; private set; }

    private List<BattleEntity> _battleEntities = new List<BattleEntity>();
    public Queue<BattleEntity> colaDeIniciativa = new Queue<BattleEntity>();
    public Queue<BattleEntity> entitiesAlreadyUsedTurn = new Queue<BattleEntity>();

    [SerializeField] private BattleEntity _currentEntityTurn;
    public override void Init()
    {
        reroll_btt.onClick.AddListener(RollInitiativeOrder);
        backToMainMenu_btt.onClick.AddListener(BackToMainMenuBtt);
        passTurn_btt.onClick.AddListener(PassTurnToNextInLine);
        turnCounter = 0;
        Populate();
    }

    private void Update()
    {
        turns_counter.text = turnCounter.ToString();
    }

    private void RollInitiativeOrder()
    {
        entitiesAlreadyUsedTurn.Clear();
        colaDeIniciativa.Clear();
        
        foreach (BattleEntity battleEntity in _battleEntities)
        {
            int rgn = Random.Range(0, 21);
            rgn += battleEntity.initMod;
            battleEntity.SetInit(rgn);
        }

        List<BattleEntity> listaEnOrden = _battleEntities.OrderByDescending(ent => ent.initRoll).ToList();

        for (int i = 0; i < listaEnOrden.Count; i++)
        {
            entitiesAlreadyUsedTurn.Enqueue(listaEnOrden[i]);
            listaEnOrden[i].transform.SetParent(characterParent_aux);
            
        }
        
        
        for (int y = 0; y < _battleEntities.Count; y++)
        {
            BattleEntity battleEnt = entitiesAlreadyUsedTurn.Dequeue();
            battleEnt.transform.SetParent(characterParent);
            
            colaDeIniciativa.Enqueue(battleEnt);
        }
        
        //set first in line
        _currentEntityTurn = colaDeIniciativa.Peek();



    }
    
    
    private void OnDisable()
    {
        ClearScreen();
    }

    private void ClearScreen()
    {
        
        foreach (BattleEntity go in _battleEntities)
        {
            Destroy(go.gameObject);
        }
        _battleEntities.Clear();
        _battleEntities.Clear();
    }

    private void Populate()
    {
        int count = 0;
        foreach (CharIDandAmount c in _characterPool.GetCurrentBattleParties())
        {
            Character newChar = _characterPool.GetAllCharacters().Find(x => x.id == c.charID);

            for (int i = 0; i < c.amount; i++)
            {
                BattleEntity newEntity = Instantiate<BattleEntity>(entity_prefab, characterParent);
                newEntity.SetData(newChar.MaxHP, newChar.characterName + " " + i, newChar.IniciativeModifier, count);
                _battleEntities.Add(newEntity);
                count++;
                newEntity.onPressedConditionPanelToggle += ToggleConditionPanel;
                newEntity.onPressedDelete += RemoveEntityFromBattle;
            }
            
        }

        RollInitiativeOrder();
    }

    private void BackToMainMenuBtt()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.MainMenu);
    }

    private void PassTurnToNextInLine()
    {
        while (colaDeIniciativa.Peek() == null)
        {
            colaDeIniciativa.Dequeue();
        }
        
        BattleEntity entToLastInLine = colaDeIniciativa.Dequeue();
        
        
        entToLastInLine.transform.SetParent(characterParent_aux);
        entToLastInLine.transform.SetParent(characterParent);
        entitiesAlreadyUsedTurn.Enqueue(entToLastInLine);
        
        if (colaDeIniciativa.Count == 0)
        {
            Debug.Log("Entro aca");
            turnCounter++;
            RestartTurnQueue();
        }
            
        _currentEntityTurn = colaDeIniciativa.Peek();
        _currentEntityTurn.EntityTurnBegin();
        
        
    }

    private void RestartTurnQueue()
    {
        for (int i = 0; i < _battleEntities.Count; i++)
        {
            colaDeIniciativa.Enqueue(entitiesAlreadyUsedTurn.Dequeue());
        }
    }

    private void ToggleConditionPanel(BattleEntity ent)
    {
        conditionPanel.gameObject.SetActive(!conditionPanel.gameObject.activeInHierarchy);
        conditionPanel.SetCurrentBattleEntity(ent);
    }

    private void RemoveEntityFromBattle(BattleEntity ent)
    {
        //arreglar esto
        
//        _battleEntities.Remove(ent);
//        Destroy(ent.gameObject);
//
//        
//        if (_currentEntityTurn == ent)
//        {
//            colaDeIniciativa.Dequeue();
//            Debug.Log("borraste el primero");
//            _currentEntityTurn = colaDeIniciativa.Peek();
//            Debug.Log("El primero es " + _currentEntityTurn.characterName);
//        }
        
    }
    
    
    
}
