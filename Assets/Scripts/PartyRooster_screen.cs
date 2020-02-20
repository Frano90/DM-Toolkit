using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyRooster_screen : Screen
{
    [SerializeField] private PartyTemplate _partyTemplate_prefab;
    [SerializeField] private Transform parent;
    private List<PartyTemplate> _partyTemplates = new List<PartyTemplate>();

    [SerializeField] private Button deleteParties_btt;
    [SerializeField] private Button mainMenu_btt;

    private void Start()
    {
        deleteParties_btt.onClick.AddListener(DeletePartiesSelected);
        mainMenu_btt.onClick.AddListener(GoBackToMainMenu);
    }

    private void GoBackToMainMenu()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.MainMenu);
    }

    private void DeletePartiesSelected()
    {
        for (int j = _partyTemplates.Count - 1; j >= 0; j--)
        {
            if (_partyTemplates[j].isSelected)
            {
                for (int i = _characterPool.GetAllParties().Count - 1; i >= 0; i--)
                {
                    if (_characterPool.GetAllParties()[i].PartyName == _partyTemplates[j].partyName)
                    {
                        _characterPool.GetAllParties().RemoveAt(i);
                    }
                }
            }
        }

        SaveSystem.SaveParties(_characterPool.GetAllParties());
        GoBackToMainMenu();
    }

    public override void Init()
    {
        Populate();
    }

    private void Populate()
    {
        foreach (PartyDATA party in _characterPool.GetAllParties())
        {
            
            if (!ValidateParty(party))
                continue;
            
            PartyTemplate newParty = Instantiate<PartyTemplate>(_partyTemplate_prefab, parent);
            newParty.SetData(party.integrantes, party.PartyName);
            _partyTemplates.Add(newParty);
        }
    }

    private bool ValidateParty(PartyDATA party)
    {
        int count = 0;
        for (int i = 0; i < party.integrantes.Count; i++)
        {
            for (int j = 0; j < _characterPool.GetAllCharacters().Count; j++)
            {
                if (party.integrantes[i].charID == _characterPool.GetAllCharacters()[j].id)
                {
                    count++;
                }
            }
        }
        if (count == party.integrantes.Count)
        {
            return true;
        }
        else
        {
            return false;
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
