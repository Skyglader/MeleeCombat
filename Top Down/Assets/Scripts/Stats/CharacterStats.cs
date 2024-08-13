using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/CharacterStats")]
public class CharacterStats : Stats
{
    [Header("Health")]
    public int vitality;
    public int dmgLVL;
    public int fireRate;
}
