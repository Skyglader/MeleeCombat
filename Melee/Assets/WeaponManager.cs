using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS
{
    public class WeaponManager : MonoBehaviour
    {
       [SerializeField] MeleeWeaponDamageCollider meleeDamageCollider;

        private void Awake()
        {
            meleeDamageCollider = GetComponentInChildren<MeleeWeaponDamageCollider>();
        }

        public void SetWeaponDamage(CharacterManager character, WeaponItem weapon)
        {
            meleeDamageCollider.characterCausingDamage = character;
            meleeDamageCollider.physicalDamage = weapon.physicalDamage;
            meleeDamageCollider.magicDamage = weapon.magicDamage;
            
        }
    }
}
