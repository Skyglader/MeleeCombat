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
        [SerializeField] float walkingSpeed = 2f;
        [SerializeField] float runningSpeed = 5f;
        [SerializeField] float rotationSpeed = 15f;

        [Header("Dodge")]
        private Vector3 rollDirection;
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

            if (PlayerInputManager.instance.moveAmount > 0.5f)
            {
                player.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
            }
            else if (PlayerInputManager.instance.moveAmount <= 0.5f)
            {
                player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
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

        public void AttemptToPerformDodge()
        {
            
            if (player.isPerformingAction == true)
            {
                Debug.Log("returned");
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
            }
        }
    }
}
