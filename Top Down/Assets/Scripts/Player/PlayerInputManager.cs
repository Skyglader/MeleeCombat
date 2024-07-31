using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerControls playerControls;

    public Vector2 movement;
    public Vector2 movementDir;

    public static PlayerInputManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movement = i.ReadValue<Vector2>();
            
        }
        playerControls.Enable();
    }

    public Vector2 GetMoveDirection()
    {
        movementDir = movement.normalized;
        return movementDir;
    }
}
