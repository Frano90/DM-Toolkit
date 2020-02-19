﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterRooster_screen : Screen
{
    [SerializeField] private CharacterRoosterTemplate _characterRoosterTemplate_prefab;
    [SerializeField] private Transform parentContainer;
    [SerializeField] private Button mainMenu_btt;
    [SerializeField] private Button deleteSelectedCharacters_btt;
    
    private List<CharacterRoosterTemplate> _roosterTemplates = new List<CharacterRoosterTemplate>();


    private void Start()
    {
        mainMenu_btt.onClick.AddListener(ReturnToMainMenu);
        deleteSelectedCharacters_btt.onClick.AddListener(DeleteCharactersSelected);
    }

    public override void Init()
    {
        Populate();
    }

    private void Populate()
    {
        foreach (Character ch in _characterPool.GetAllCharacters())
        {
            CharacterRoosterTemplate newCharacterTemplate = Instantiate<CharacterRoosterTemplate>(_characterRoosterTemplate_prefab, parentContainer);
            newCharacterTemplate.SetData(ch.characterName, ch.id);
            _roosterTemplates.Add(newCharacterTemplate);
        }
    }

    private void DeleteCharactersSelected()
    {
        foreach (CharacterRoosterTemplate template in _roosterTemplates)
        {
            if (template.isSelected)
            {
                for (int i = _characterPool.GetAllCharacters().Count -1; i > 0; i--)
                {
                    if (template.ID == _characterPool.GetAllCharacters()[i].id)
                    {
                        Debug.Log("Se va el personaje "  + _characterPool.GetAllCharacters()[i].characterName);
                        _characterPool.GetAllCharacters().RemoveAt(i);
                    }
                }
            }
        }
        SaveSystem.SaveCharacters(_characterPool.GetAllCharacters());
        ReturnToMainMenu();
    }
    
    private void ReturnToMainMenu()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.MainMenu);
    }
    
    private void OnDisable()
    {
        ClearScreen();
    }

    private void ClearScreen()
    {
        foreach (CharacterRoosterTemplate template in _roosterTemplates)
        {
            Destroy(template.gameObject);
        }
        _roosterTemplates.Clear();
    }
}
