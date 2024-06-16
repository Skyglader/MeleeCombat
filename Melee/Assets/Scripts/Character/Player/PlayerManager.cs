using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class PlayerManager : CharacterManager
    {
        [HideInInspector] public PlayerLocomotionManager playerLocomotionManager;
        [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;
        [HideInInspector] public PlayerStatsManager playerStatsManager;

        
        protected override void Awake()
        {
            base.Awake();
            playerStatsManager = GetComponent<PlayerStatsManager>();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
            playerAnimatorManager = GetComponent <PlayerAnimatorManager>();
            playerStatsManager.maxStamina = playerStatsManager.CalaculateStaminaBasedOnEnduranceLevel(playerStatsManager.endurance);
            playerStatsManager.CurrentStamina = playerStatsManager.maxStamina;
            PlayerUIManager.instance.playerUIHudManager.SetMaxStaminaValue(playerStatsManager.maxStamina);

        }

        protected override void Update()
        {
            base.Update();

            //Handle Movement
            playerLocomotionManager.HandleAllMovement();

            playerStatsManager.RegenerateStamina();
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();

            PlayerCamera.instance.HandleAllCameraActions();
        }

       
    }
}
