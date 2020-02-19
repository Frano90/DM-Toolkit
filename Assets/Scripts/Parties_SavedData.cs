using System;
using System.Collections.Generic;

[Serializable]
public class Parties_SavedData
{
    public List<PartyDATA> partiesCreated = new List<PartyDATA>();

    public Parties_SavedData(List<PartyDATA> parties)
    {
        for (int i = 0; i < parties.Count; i++)
        {
            partiesCreated.Add(parties[i]);
        }
    }
    
}
