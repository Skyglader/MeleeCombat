using DS;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


namespace DS
{
    public class PlayerInventoryManager : CharacterInventoryManager
    {
        public WeaponItem currentRightHandWeapon;
        public WeaponItem currentLeftHandWeapon;

        [Header("Quick Slots")]
        public WeaponItem[] weaponsInRightHandSlot = new WeaponItem[3];
        public int rightHandWeaponIndex = 0;

        protected override void Awake()
        {
            base.Awake();
        }
        public int RightHandWeaponIndex
        {
            get { return rightHandWeaponIndex; }
            set
            {
                rightHandWeaponIndex = value;
                WeaponItem newWeapon = Instantiate(WorldItemDatabase.Instance.GetWeaponByID(value));
                player.playerInventoryManager.currentRightHandWeapon = newWeapon;
                player.playerEquipmentManager.LoadRightWeapon();
                
            }
    
        }

    }
}
