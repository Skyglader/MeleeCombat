using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace DS
{
    public class CharacterLocomotionManager : MonoBehaviour
    {
        CharacterManager character;
        [Header("Ground Check & Jump")]
        [SerializeField] protected float gravityForce = -5.55f;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float groundCheckSphereRadius = 1;
        [SerializeField] protected Vector3 yVelocity;
        [SerializeField] protected float groundedYVelocity = -20f;
        [SerializeField] protected float fallStartYVelocity = -5f;
        protected bool fallingVelocityHasBeenSet = false;
        protected float inAirTimer = 0;

       protected virtual void Awake()
        {
           character = GetComponent<CharacterManager>();
        }

       protected virtual void Update()
        {
            HandleGroundCheck();

            if (character.isGrounded)
            {
                if (yVelocity.y < 0)
                {
                    fallingVelocityHasBeenSet = false;

                    yVelocity.y = groundedYVelocity;
                }
            }
            else
            {
                if (!character.isJumping && !fallingVelocityHasBeenSet)
                {
                    fallingVelocityHasBeenSet = true;
                    yVelocity.y = fallStartYVelocity;
                }
                inAirTimer += Time.deltaTime;
                character.animator.SetFloat("InAirTimer", inAirTimer);
                yVelocity.y += gravityForce * Time.deltaTime;
                
                
            }

            character.characterController.Move(yVelocity * Time.deltaTime);
        }

       protected void HandleGroundCheck()
       {
           character.isGrounded = Physics.CheckSphere(character.transform.position, groundCheckSphereRadius, groundLayer);
       }

       
    }
}
