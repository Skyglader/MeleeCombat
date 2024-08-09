using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLocomotionManager : CharacterLocomotionManager
{
    
    [SerializeField] PlayerManager player;
    [SerializeField] float playerSpeed = 20;
    [SerializeField] float slideDampen;
    [SerializeField] float rotateSpeed;
    [SerializeField] float decelerationSpeed;
    
    private void Awake()
    {
       player = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        HandleRotations();
        
    }

    private void FixedUpdate()
    {
        HandleMovements();
    }

    private void HandleRotations()
    {
        if (!canMove)
        {
            return;
        }
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = player.playerCamera.cam.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(worldMousePos.x - transform.position.x, worldMousePos.y - transform.position.y);

        // Ensure the direction is not zero
        if (direction != Vector2.zero)
        {
            // Calculate the angle in degrees and rotate the player accordingly
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

    }

    private void HandleMovements()
    {
        if (!canMove)
        {
            player.rb.velocity = Vector2.zero;
            return;
        }
       Vector2 movementDir = player.playerInputManager.GetMoveDirection();
        if (movementDir != Vector2.zero)
        {
            player.rb.velocity = Vector2.Lerp(player.rb.velocity, Vector2.zero, decelerationSpeed);
            player.rb.velocity = movementDir * playerSpeed * (1.0f - decelerationSpeed); ;
        }
        else
        {
            player.rb.velocity *= slideDampen;
        }
    }

    
}
