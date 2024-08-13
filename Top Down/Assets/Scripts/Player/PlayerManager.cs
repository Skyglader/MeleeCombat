using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    public PlayerLocomotionManager playerLocomotionManager;
    public PlayerCamera playerCamera;
    public PlayerInputManager playerInputManager;
    public PlayerStatsManager playerStatsManager;
    public PlayerCombatManager playerCombatManager;
    

    public override void Awake()
    {
        base.Awake();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        playerInputManager = GetComponent<PlayerInputManager>();
        rb = GetComponent<Rigidbody2D>();
        statsManager = GetComponent<PlayerStatsManager>();
        animationManager = GetComponent<CharacterAnimationManager>();
        characterCollider = GetComponent<Collider2D>();
        playerCombatManager = GetComponent<PlayerCombatManager>();
        
    }
    public override void Start()
    {
        base.Start();
        playerCamera = GameObject.Find("CameraHolder").GetComponent<PlayerCamera>();
    }
}
