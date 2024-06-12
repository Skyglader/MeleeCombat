using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DS
{
    
    public class PlayerInputManger : MonoBehaviour
    {
        public static PlayerInputManger instance;
        PlayerControls playerControls;

        [SerializeField] Vector2 movementInput;

        private void Awake()
        {
          
        }

        private void Start()
        {
           
        }

        void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }

       
    }
}
