using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Effects/Instant Effects/Take Damage")]
public class TakeDamageEffect : InstantCharacterEffect
{
    [Header("Information")]
    public float damage;
    public override void ProcessEffect(CharacterManager character)
    {
        character.statsManager.DamageTarget(damage);
    }
}
