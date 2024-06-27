using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {
        public PlayerManager player;
        public float verticalMovement;
        public float horizontalMovement;
        

        [Header("Movement Settings")]
        private Vector3 moveDirection;
        private Vector3 targetRotationDirection;
        [SerializeField] float jumpHeight = 4;
        [SerializeField] float walkingSpeed = 2f;
        [SerializeField] float runningSpeed = 5f;
        [SerializeField] float sprintingSpeed = 6.5f;
        [SerializeField] float rotationSpeed = 15f;
        [SerializeField] int sprintingStaminaCost = 2;

        [Header("Dodge")]
        private Vector3 rollDirection;
        [SerializeField] float dodgeStaminaCost = 25f;
        [SerializeField] float jumpStaminaCost = 25f;

        [Header("Flags")]
        public bool isSprinting = false;
        protected override void Awake()
        {
            base.Awake();

            player = GetComponent<PlayerManager>();
        }
        public void HandleAllMovement()
        {
            HandleGroundedMovement();
            HandleRotation();
            //aerial movement
        }

        private void GetVerticalAndHorizontalInputs()
        {
            verticalMovement = PlayerInputManager.instance.verticalInput;
            horizontalMovement = PlayerInputManager.instance.horizontalInput;

        }
        private void HandleGroundedMovement()
        {
            if (!player.canMove)
                return;
            GetVerticalAndHorizontalInputs();
            moveDirection = PlayerCamera.instance.transform.forward * verticalMovement;
            moveDirection = moveDirection + PlayerCamera.instance.transform.right * horizontalMovement;

            moveDirection.Normalize();
            moveDirection.y = 0;

            if (isSprinting)
            {
                player.characterController.Move(moveDirection * sprintingSpeed * Time.deltaTime);
            }
            else
            {
                if (PlayerInputManager.instance.moveAmount > 0.5f)
                {
                    player.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
                }
                else if (PlayerInputManager.instance.moveAmount <= 0.5f)
                {
                    player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
                }
            }
            
        }

        private void HandleRotation()
        {
            if (!player.canRotate)
                return;
            targetRotationDirection = Vector3.zero;
            targetRotationDirection = PlayerCamera.instance.cameraObject.transform.forward * verticalMovement;
            targetRotationDirection = targetRotationDirection + PlayerCamera.instance.cameraObject.transform.right * horizontalMovement;
            targetRotationDirection.Normalize();
            targetRotationDirection.y = 0;

            if (targetRotationDirection == Vector3.zero)
            {
                targetRotationDirection = transform.forward;
            }

            Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = targetRotation;
        }
        public void HandleSprinting()
        {
            if (player.isPerformingAction)
            {
                isSprinting = false;
            }

            if (player.playerStatsManager.CurrentStamina <= 0)
            {
                isSprinting = false;
                return;
            }

            if (PlayerInputManager.instance.moveAmount >= 0.5f)
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }

            if (isSprinting)
            {
                player.playerStatsManager.CurrentStamina -= sprintingStaminaCost * Time.deltaTime;
            }
        }
        public void AttemptToPerformDodge()
        {
            
            if (player.isPerformingAction == true)
            {
                Debug.Log("returned");
                return;
            }

            if (player.playerStatsManager.CurrentStamina <= 0)
            {
                return;
            }
            if (PlayerInputManager.instance.moveAmount > 0)
            {
                Debug.Log("entered");
                rollDirection = PlayerCamera.instance.cameraObject.transform.forward * verticalMovement;
                rollDirection += PlayerCamera.instance.cameraObject.transform.right * horizontalMovement;

                rollDirection.y = 0;
                rollDirection.Normalize();
                Quaternion playerRotation = Quaternion.LookRotation(rollDirection);
                player.transform.rotation = playerRotation;
               
                player.playerAnimatorManager.PlayerTargetActionAnimation("RollForward", true);

                player.playerStatsManager.CurrentStamina -= dodgeStaminaCost;
            }

            
        }

        public void AttemptToPerformJump()
        {
            if (player.isPerformingAction == true)
            {
                Debug.Log("returned");
                return;
            }

            if (player.playerStatsManager.CurrentStamina <= 0)
            {
                return;
            }

            if (player.isJumping)
            {
                return;
            }

            if (!player.isGrounded)
            {
                return;
            }

            Debug.Log("Jump executed");
            player.playerAnimatorManager.PlayerTargetActionAnimation("StartJump", false);

            player.isJumping = true;
            player.playerStatsManager.CurrentStamina -= jumpStaminaCost;
        }

        public void ApplyJumpingVelocity()
        {
            yVelocity.y = Mathf.Sqrt(jumpHeight * -1 * gravityForce);
        }
    }

    
}
