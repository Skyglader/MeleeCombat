using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DS
{
    public class ItemBasedAction : ScriptableObject
    {
        public int actionID;
        
        public virtual void AttemptToPerformAction(PlayerManager playerPerformingAction, WeaponItem weaponPerformingAction)
        {

        }
    }
}
