using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class CharacterStatsManager : MonoBehaviour
    {
        PlayerManager player;
        CharacterManager character;
        [Header("Stats")]
        public int endurance = 1;
        public float _currentStamina;
        public int maxStamina;

        [Header("Stamina Regeneration")]
        private float staminaRegenerationTimer = 0;
        private float staminaTickTimer = 0;
        [SerializeField] private float staminaRegenerationAmount = 2;
        [SerializeField] float staminaRegenerationDelay = 2f;

        public float CurrentStamina
        {
            get { return _currentStamina; }
            set
            {
                ResetStaminaRegenTimer(_currentStamina, value);
                PlayerUIManager.instance.playerUIHudManager.SetNewStaminaValue(_currentStamina, value);
                _currentStamina = value;
            }
        }

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
            player = GetComponent<PlayerManager>();

        }
        public int CalaculateStaminaBasedOnEnduranceLevel(int endurance)
        {
            float stamina = 0;

            stamina = endurance * 10;

            return Mathf.RoundToInt(stamina);
        }

        public virtual void RegenerateStamina()
        {
            if (player.playerLocomotionManager.isSprinting)
                return;

            if (player.isPerformingAction)
                return;

            staminaRegenerationTimer += Time.deltaTime;

            if (staminaRegenerationTimer >= staminaRegenerationDelay)
            {
                if (CurrentStamina < maxStamina)
                {
                    staminaTickTimer += Time.deltaTime;

                    if (staminaTickTimer >= 0.1f)
                    {
                        staminaTickTimer = 0;
                        CurrentStamina += staminaRegenerationAmount;
                    }
                }
            }
        }

        public virtual void ResetStaminaRegenTimer(float oldValue, float newValue)
        {
            if (newValue < oldValue)
                staminaRegenerationTimer = 0;
        }
    }

   
}
