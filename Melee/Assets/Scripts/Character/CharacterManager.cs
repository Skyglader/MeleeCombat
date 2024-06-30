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

        [Header("Flags")]
        public bool isPerformingAction = false;
        public bool canRotate = true;
        public bool isJumping = false;
        public bool isGrounded = true;
        public bool canMove = true;
        public bool applyRootMotion = false;
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);

            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            animator.SetBool("IsGrounded", isGrounded);
        }

        protected virtual void LateUpdate()
        {
            
        }

       
    }
}

