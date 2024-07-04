using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DS
{
    public class CharacterManager : MonoBehaviour
    {
        [HideInInspector] public CharacterController characterController;
        [HideInInspector] public Animator animator;
        [HideInInspector] public PlayerStatsManager playerStatsManager;
        [HideInInspector] public CharacterEffectsManager characterEffectsManager;
        [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;

        [Header("Flags")]
        public bool isPerformingAction = false;
        public bool canRotate = true;
        public bool isJumping = false;
        public bool isGrounded = true;
        public bool canMove = true;
        public bool applyRootMotion = false;
        public bool isDead = false;
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);

            characterController = GetComponent<CharacterController>();
            characterEffectsManager = GetComponent<CharacterEffectsManager>();
            playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
            animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            animator.SetBool("IsGrounded", isGrounded);
        }

        protected virtual void LateUpdate()
        {
            
        }

        public virtual IEnumerator ProcessDeathEvent(bool manuallySelectDeathAnimation = false)
        {
           if (playerStatsManager.CurrentHealth <= 0)
            {
                isDead = true;

                if (!manuallySelectDeathAnimation)
                {
                    playerAnimatorManager.PlayerTargetActionAnimation("Dead_01", true);
                }
            }

           yield return new WaitForSeconds(5f);

            //award money

        }

        public virtual void ReviveCharacter()
        {

        }

       
    }
}

