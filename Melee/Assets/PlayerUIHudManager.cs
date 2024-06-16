using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class PlayerUIHudManager : MonoBehaviour
    {
        [SerializeField] UI_StatBar staminaBar;

        public void SetNewStaminaValue(float oldValue, float newValue)
        {
            staminaBar.SetStat(newValue);
        }

        public void SetMaxStaminaValue(float maxStamina)
        {
            staminaBar.SetMaxStat(maxStamina);
        }
    }
}
