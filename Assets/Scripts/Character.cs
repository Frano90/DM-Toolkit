using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Character 
{
    public string characterName { get;  set; }
    public int id { get; set; }
    public int MaxHP { get;  set; }
    public int ArmorClass { get;  set; }
    public int IniciativeModifier { get;  set; }
    public int PassivePerception { get;  set; }
    public bool isPC { get; set; }

}

public enum Conditions
{
    Blinded,
    Charmed,
    Deafened,
    Fatigued,
    Frightened,
    Grappled,
    Incapacitated,
    Invisible,
    Paralized,
    Petrified,
    Poisoned,
    Prone,
    Restrained,
    Stunned,
    Unconscious
}
