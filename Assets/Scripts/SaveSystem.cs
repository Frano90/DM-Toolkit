using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveCharacters(List<Character> charactersCreated)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/charactersSaved.fag";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        Characters_SavedData savedChars = new Characters_SavedData(charactersCreated);
        
        formatter.Serialize(stream, savedChars);
        stream.Close();
    }
    
    public static void SaveParties(List<PartyDATA> partiesCreated)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/partiesSaved.fag";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        Parties_SavedData savedParties = new Parties_SavedData(partiesCreated);
        
        formatter.Serialize(stream, savedParties);
        stream.Close();
    }
    
    public static Parties_SavedData LoadParties()
    {
        string path = Application.persistentDataPath + "/partiesSaved.fag";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
        
            Parties_SavedData savedParties = formatter.Deserialize(stream) as Parties_SavedData;
            stream.Close();

            return savedParties;
        }
        else
        {
            Debug.LogError("Cant find the file");
            return null;
        }
        
        
    }

    public static Characters_SavedData LoadCharacters()
    {
        string path = Application.persistentDataPath + "/charactersSaved.fag";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            Characters_SavedData charactersSavedData = formatter.Deserialize(stream) as Characters_SavedData;
            stream.Close();

            return charactersSavedData;
        }
        else
        {
            Debug.LogError("No se encontro el file en " + path);
            return null;
        }
    }

    public static void ResetData()
    {
        List<PartyDATA> zeroParties = new List<PartyDATA>();
        SaveParties(zeroParties);
    }
}
