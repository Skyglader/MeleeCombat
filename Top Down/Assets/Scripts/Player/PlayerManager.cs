using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    public PlayerLocomotionManager playerLocomotionManager;
    public PlayerCamera playerCamera;
    public PlayerInputManager playerInputManager;
    public PlayerStatsManager playerStatsManager;
    

    private void Awake()
    {
        playerStatsManager = GetComponent<PlayerStatsManager>();
        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        playerInputManager = GetComponent<PlayerInputManager>();
        rb = GetComponent<Rigidbody2D>();
        statsManager = GetComponent<PlayerStatsManager>();
        animationManager = GetComponent<CharacterAnimationManager>();
        characterCollider = GetComponent<Collider2D>();
    }
    private void Start()
    {
        
        playerCamera = GameObject.Find("CameraHolder").GetComponent<PlayerCamera>();
    }
}
