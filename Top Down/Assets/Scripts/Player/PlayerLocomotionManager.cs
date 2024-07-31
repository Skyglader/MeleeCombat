using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLocomotionManager : MonoBehaviour
{
    [SerializeField] PlayerManager player;
    [SerializeField] float playerSpeed = 20;

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
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = player.playerCamera.cam.ScreenToWorldPoint(mousePos);
        Vector3 dir = worldMousePos - transform.position;
        Vector2 direction = new Vector2(worldMousePos.x - transform.position.x, worldMousePos.y - transform.position.y);

        // Ensure the direction is not zero
        if (direction != Vector2.zero)
        {
            // Calculate the angle in degrees and rotate the player accordingly
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

    }

    private void HandleMovements()
    {
       Vector2 movementDir = player.playerInputManager.GetMoveDirection();
        if (movementDir != Vector2.zero)
        {
            player.rb.velocity = movementDir * playerSpeed;
        }
        else
        {
            player.rb.velocity = Vector2.zero;
        }
    }
}
