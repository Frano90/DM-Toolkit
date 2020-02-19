using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChararcterSelection_screen : Screen
{
    [SerializeField] private CharacterTemplate charTemplate_prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private Button confirmParty_btt;
    [SerializeField] private Button backToMenu_btt;
    [SerializeField] private Button closeNamePanel_btt;
    [SerializeField] private Button confirmPartyName_btt;
    [SerializeField] private GameObject partynamePanel;
    [SerializeField] private InputField partyname_input;

    private List<CharIDandAmount> currentCharactersID = new List<CharIDandAmount>();
    private List<CharacterTemplate> templates = new List<CharacterTemplate>();
    

    private void Start()
    {
        confirmParty_btt.onClick.AddListener(TurnOnNamePanel);
        backToMenu_btt.onClick.AddListener(BackToMenu);
        closeNamePanel_btt.onClick.AddListener(ClosePanel);
        confirmPartyName_btt.onClick.AddListener(ConfirmName);
    }

    public override void Init()
    {
        partynamePanel.SetActive(false);
        Populate();
    }

    private void OnDisable()
    {
        ClearScreen();
    }

    private void ClearScreen()
    {
        
        foreach (CharacterTemplate go in templates)
        {
            Destroy(go.gameObject);
        }
        templates.Clear();
        currentCharactersID.Clear();
    }

    private void Populate()
    {
        foreach (Character ch in _characterPool.GetAllCharacters())
        {
            CharacterTemplate newCharacterTemplate = Instantiate<CharacterTemplate>(charTemplate_prefab, parent);
            newCharacterTemplate.SetData(ch.characterName, ch.id);
            templates.Add(newCharacterTemplate);
        }
    }

    private void TurnOnNamePanel()
    {
        partynamePanel.SetActive(true);
    }
    
    private void CreateParty()
    {
        foreach (CharacterTemplate ct in templates)
        {
            if (ct.isSelected)
            {
                CharIDandAmount newChar = new CharIDandAmount();
                newChar.charID = ct.ID;
                newChar.amount = ct.amount;
                
                currentCharactersID.Add(newChar);
            }
            
        }
        
        PartyDATA newParty = new PartyDATA();
        newParty.PartyName = partyname_input.text;
        newParty.integrantes = new List<CharIDandAmount>();

        for (int i = 0; i < currentCharactersID.Count; i++)
        {
            newParty.integrantes.Add(currentCharactersID[i]);
        }

        _characterPool.AddNewParty(newParty);
        SaveSystem.SaveParties(_characterPool.GetAllParties());
        BackToMenu();
    }

    private void BackToMenu()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.MainMenu);
    }

    private void ClosePanel()
    {
        partynamePanel.SetActive(false);
    }
    
    private void ConfirmName()
    {
        CreateParty();
    }
}
