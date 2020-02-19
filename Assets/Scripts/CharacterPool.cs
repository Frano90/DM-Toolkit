using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "CharacterPool", menuName = "CharacterPool")]
public class CharacterPool : ScriptableObject
{
    [SerializeField] private List<Character> allCharacters = new List<Character>();
    
    [SerializeField] private List<PartyDATA> partiesLoaded = new List<PartyDATA>();

    [SerializeField] private List<CharIDandAmount> currentBattleCharacters = new List<CharIDandAmount>();

    public int idCharacterCount = 0;
    public void AddNewCharacter(Character newCharacter)
    {
        allCharacters.Add(newCharacter);
    }

    public int AddCharacterIDCount()
    {
        idCharacterCount++;
        return idCharacterCount;
    }
    

    public void AddNewParty(PartyDATA newParty)
    {
        //Si no esta en la lista...
        List<PartyDATA> query = partiesLoaded.Where(p => p.PartyName == newParty.PartyName).ToList();

        if (query.Count == 0)
        {
            partiesLoaded.Add(newParty);
        }
    }

    public void SetPartiesToBattle(List<CharIDandAmount> battleCharacters)
    {
        currentBattleCharacters = battleCharacters;
    }


    public List<Character> GetAllCharacters()
    {
        return allCharacters;
    }
    
    public List<PartyDATA> GetAllParties()
    {
        return partiesLoaded;
    }
    
    public List<CharIDandAmount> GetCurrentBattleParties()
    {
        return currentBattleCharacters;
    }

    private void OnDisable()
    {
        allCharacters.Clear();
        partiesLoaded.Clear();
        currentBattleCharacters.Clear();
    }
}
