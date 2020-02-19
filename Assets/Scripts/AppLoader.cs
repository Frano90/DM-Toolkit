using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLoader : MonoBehaviour
{
    [SerializeField] private CharacterPool pool;
    
    void Start()
    {
        LoadCharacters();
        LoadParties();
    }

    private void LoadParties()
    {
        List<PartyDATA> loadedParties = new List<PartyDATA>();
        Parties_SavedData partiesSavedData = SaveSystem.LoadParties();

        if (partiesSavedData == null)
            return;
        
        
        loadedParties = SaveSystem.LoadParties().partiesCreated;

        
        foreach (PartyDATA party in loadedParties)
        {
            pool.AddNewParty(party);
        }
    }

    private void LoadCharacters()
    {
        List<Character> loadedCharacters = new List<Character>();
        loadedCharacters = SaveSystem.LoadCharacters().charactersSaved;

        if(loadedCharacters == null)
            return;

        foreach (Character character in loadedCharacters)
        {
            pool.AddNewCharacter(character);
        }
    }
}
