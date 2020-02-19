using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation_screen : Screen
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private InputField maxHPInputField;
    [SerializeField] private InputField perceptionInputField;
    [SerializeField] private InputField initInputField;
    [SerializeField] private InputField armorInputField;
    [SerializeField] private PCorNPC_btt _pCorNpcBtt;

    [SerializeField] private Button finish;
    [SerializeField] private Button exit;

    private Character currentChar;

    private void Start()
    {
        finish.onClick.AddListener(SaveAndFinish);
        exit.onClick.AddListener(BackToMainMenu);
        
        currentChar = new Character();
    }

    private void SaveAndFinish()
    {
//        if (!ValidateInput())
//        {
//            Debug.Log("Faltan campos por completar");
//            return;
//        }

        currentChar = new Character();
        
        currentChar.characterName = nameInputField.text;
        currentChar.ArmorClass = Int32.Parse(armorInputField.text);
        currentChar.IniciativeModifier = Int32.Parse(initInputField.text);
        currentChar.PassivePerception = Int32.Parse(perceptionInputField.text);
        currentChar.MaxHP = Int32.Parse(maxHPInputField.text);
        currentChar.isPC = _pCorNpcBtt.IsPCThisCharacter();

        currentChar.id = _characterPool.AddCharacterIDCount();
        _characterPool.AddNewCharacter(currentChar);
        
        SaveSystem.SaveCharacters(_characterPool.GetAllCharacters());
        
        BackToMainMenu();
    }

    private void BackToMainMenu()
    {
        Screen_controller.instance.ChangeScreen(ScreenType.MainMenu);
    }

    private bool ValidateInput()
    {
        if (nameInputField.text == "")
            return false;
        
        if (maxHPInputField.text == "")
            return false;
        
        if (perceptionInputField.text == "")
            return false;
        
        if (initInputField.text == "")
            return false;
        
        if (armorInputField.text == "")
            return false;

        return true;
    }
    
}
