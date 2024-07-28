using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS
{
    public class WeaponItem : Item
    {
        [Header("Weapon model")]
        public GameObject weaponModel;

        [Header("Weapon Requirements")]
        public int strengthREQ = 0;
        public int dexREQ = 0;

        [Header("Weapon Base Damage")]
        public int physicalDamage = 0;
        public int magicDamage = 0;

        [Header("Stamina Costs")]
        public int baseStaminaCost = 20;

        [Header("Base Poise Damage")]
        public float poiseDamage = 10;
    }
}
