using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Characters_SavedData
{
    public List<Character> charactersSaved = new List<Character>();
    
    public Characters_SavedData(List<Character> characters)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            charactersSaved.Add(characters[i]);
        }
    }
    
}
