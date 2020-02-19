using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public ScreenType screenType;
    [SerializeField] protected CharacterPool _characterPool;

    public virtual void Init()
    {

    }
    
    
}

public enum ScreenType
{
    MainMenu,
    CharacterCreation,
    CharacterSelection,
    PartySelection,
    Battle,
    CharacterRooster
}
