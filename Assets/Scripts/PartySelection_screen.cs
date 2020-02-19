using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartySelection_screen : Screen
{
    [SerializeField] private PartyTemplate _partyTemplate_prefab;
    private List<PartyDATA> parties = new List<PartyDATA>();
    [SerializeField] private Transform parent;
    private List<PartyTemplate> _partyTemplates = new List<PartyTemplate>();

    [SerializeField] private Button confirm_btt;
    [SerializeField] private Button cancel_btt;

    private void Start()
    {
        confirm_btt.onClick.AddListener(ConfirmPartiesSelected);
        cancel_btt.onClick.AddListener(GoBackToMainMenu);
    }

    private void GoBackToMainMenu()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.MainMenu);
    }

    private void ConfirmPartiesSelected()
    {
        List<CharIDandAmount> battleCharacters = new List<CharIDandAmount>();
        
        foreach (PartyTemplate pt in _partyTemplates)
        {
            if (pt.isSelected)
            {
                foreach (CharIDandAmount c in pt.members)
                {
                    battleCharacters.Add(c);
                }
            }
        }
        _characterPool.SetPartiesToBattle(battleCharacters);
        Screen_controller.instance.ChangeScreen(ScreenType.Battle);
    }

    public override void Init()
    {
        parties = _characterPool.GetAllParties();
        Populate();
    }

    private void Populate()
    {
        foreach (PartyDATA party in parties)
        {
            PartyTemplate newParty = Instantiate<PartyTemplate>(_partyTemplate_prefab, parent);
            newParty.SetData(party.integrantes, party.PartyName);
            _partyTemplates.Add(newParty);
        }
    }
    
    private void OnDisable()
    {
        ClearScreen();
    }

    private void ClearScreen()
    {
        
        foreach (PartyTemplate go in _partyTemplates)
        {
            Destroy(go.gameObject);
        }
        _partyTemplates.Clear();
    }
}
