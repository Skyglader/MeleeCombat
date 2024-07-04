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
        public int _endurance = 1;
        public float _currentStamina;
        public int maxStamina;

        public int _vitality = 1;
        public float _currentHealth;
        public int maxHealth;

        [Header("Stamina Regeneration")]
        private float staminaRegenerationTimer = 0;
        private float staminaTickTimer = 0;
        [SerializeField] private float staminaRegenerationAmount = 2;
        [SerializeField] float staminaRegenerationDelay = 2f;


        public int Endurance
        {
           get { return _endurance; }
            set
            {
                _endurance = value;
                maxStamina = CalculateStaminaBasedOnEnduranceLevel(_endurance);
                PlayerUIManager.instance.playerUIHudManager.SetMaxStaminaValue(maxStamina);
                PlayerUIManager.instance.playerUIHudManager.ResetBars();
            }
        }

        public int Vitality
        {
            get { return _vitality; }
            set
            {
                _vitality = value;
                maxHealth = CalculateStaminaBasedOnEnduranceLevel(_vitality);
                PlayerUIManager.instance.playerUIHudManager.SetMaxHealthValue(maxHealth);
                PlayerUIManager.instance.playerUIHudManager.ResetBars();
            }
        }
        public float CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                ResetStaminaRegenTimer(_currentHealth, value);
                PlayerUIManager.instance.playerUIHudManager.SetNewHealthValue(_currentHealth, value);

                _currentHealth = value;

                CheckHP();
            }
        }
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

        public void CheckHP()
        {
            if (CurrentHealth <= 0)
            {
                StartCoroutine(character.ProcessDeathEvent());
            }

            if (_currentHealth > maxHealth)
            {
                _currentHealth = maxHealth;
            }
        }
        public int CalculateStaminaBasedOnEnduranceLevel(int endurance)
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

        public int CalculateHealthBasedOnVitalityLevel(int vitality)
        {
            float health = 0;

            health = vitality * 10;

            return Mathf.RoundToInt(health);
        }
    }


   

}
