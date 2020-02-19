using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_screen : Screen
{
    [SerializeField] private Button createCharacter;
    [SerializeField] private Button createParty;
    [SerializeField] private Button startBattle;
    [SerializeField] private Button characterRooster;
    private void Start()
    {
        createCharacter.onClick.AddListener(CreateNewCharacter);
        createParty.onClick.AddListener(CreateNewParty);
        startBattle.onClick.AddListener(StartBattle);
        characterRooster.onClick.AddListener(GoToCharacterRooster);
    }

    private void CreateNewCharacter()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.CharacterCreation);
    }

    private void CreateNewParty()
    {
        //uso character selection porque la idea es agrupar personajes
        Screen_controller.instance.ChangeScreen(ScreenType.CharacterSelection);
    }

    private void StartBattle()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.PartySelection);
    }

    private void GoToCharacterRooster()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.CharacterRooster);
    }
    
}
