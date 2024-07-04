using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class PlayerManager : CharacterManager
    {
        [HideInInspector] public PlayerLocomotionManager playerLocomotionManager;

        [SerializeField] bool respawnCharacter = false;

        
        protected override void Awake()
        {
            base.Awake();
            playerStatsManager = GetComponent<PlayerStatsManager>();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
            


            playerStatsManager.maxStamina = playerStatsManager.CalculateStaminaBasedOnEnduranceLevel(playerStatsManager.Endurance);
            playerStatsManager.maxHealth = playerStatsManager.CalculateHealthBasedOnVitalityLevel(playerStatsManager.Vitality);
            playerStatsManager.CurrentStamina = playerStatsManager.maxStamina;
            playerStatsManager.CurrentHealth = playerStatsManager.maxHealth;
            PlayerUIManager.instance.playerUIHudManager.SetMaxStaminaValue(playerStatsManager.maxStamina);
            PlayerUIManager.instance.playerUIHudManager.SetMaxHealthValue(playerStatsManager.maxHealth);

        }

        protected override void Update()
        {
            base.Update();

            //Handle Movement
            playerLocomotionManager.HandleAllMovement();

            playerStatsManager.RegenerateStamina();

            DebugMenu();
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();

            PlayerCamera.instance.HandleAllCameraActions();
        }

        public override IEnumerator ProcessDeathEvent(bool manuallySelectDeathAnimation = false)
        {

            PlayerUIManager.instance.playerUIPopUpManager.SendYouDiedPopUp();
            return base.ProcessDeathEvent(manuallySelectDeathAnimation);

            
        }

        private void DebugMenu()
        {
            if (respawnCharacter)
            {
                respawnCharacter = false;
                ReviveCharacter();
                isDead = false;

            }
        }

        public override void ReviveCharacter()
        {
            base.ReviveCharacter();

            playerStatsManager.CurrentHealth = playerStatsManager.maxHealth;
            playerStatsManager.CurrentStamina = playerStatsManager.maxStamina;

            playerAnimatorManager.PlayerTargetActionAnimation("Empty", false);
        }
    }
}
