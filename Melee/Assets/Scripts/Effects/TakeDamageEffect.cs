using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS
{
    [CreateAssetMenu(menuName = "Character Effects/Instant Effects/ Take Damage")]
    public class TakeDamageEffect : InstantCharacterEffect
    {
        [Header("Character Causing Damage")]
        public CharacterManager characterCausingDamage;

        [Header("Damage")]
        public float physicalDamage = 0;
        public float magicDamage = 0;

        [Header("Final Damage")]
        private float finalDamageDealt = 0; // final damage calculation

        [Header("Animation")]
        public bool playDamageAnimation = true;
        public bool manuallySelectDamageAnimation = false;
        public string damageAnimation;

        [Header("Sound FX")]
        public bool willPlayDamageSFX;

        [Header("Poise")]
        public float poiseDamage = 0;
        public bool poiseIsBroken = false;

        [Header("Direction Damage Taken From")]
        public float angleHitFrom;
        public Vector3 contactPoint;


        public override void ProcessEffect(CharacterManager character)
        {
            base.ProcessEffect(character);

            if (character.isDead)
                return;

            CalculateDamage(character);
        }


        private void CalculateDamage(CharacterManager character)
        {
            if (characterCausingDamage != null)
            {

            }

            finalDamageDealt = physicalDamage + magicDamage;

            if (finalDamageDealt <= 0)
            {
                finalDamageDealt = 1;
            }

            character.playerStatsManager.CurrentHealth -= finalDamageDealt;
        }
       
    }
}
