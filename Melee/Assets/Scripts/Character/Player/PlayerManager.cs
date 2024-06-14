using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class PlayerManager : CharacterManager
    {
        [HideInInspector] public PlayerLocomotionManager playerLocomotionManager;
        [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;
        protected override void Awake()
        {
            base.Awake();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
            playerAnimatorManager = GetComponent <PlayerAnimatorManager>();
        }

        protected override void Update()
        {
            base.Update();

            //Handle Movement
            playerLocomotionManager.HandleAllMovement();
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();

            PlayerCamera.instance.HandleAllCameraActions();
        }
    }
}
