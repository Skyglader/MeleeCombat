using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantCharacterEffect : ScriptableObject 
{
    [Header("Effect ID")]
    public int itemID;

    public abstract void ProcessEffect(CharacterManager character);
   
}
