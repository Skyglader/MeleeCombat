using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManager
{

    public EnemyLocomotionManager enemyLocomotionManager;
    public EnemyGunManager enemyGunManager;
    public override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
        statsManager = GetComponent<CharacterStatsManager>();
        animationManager = GetComponent<CharacterAnimationManager>();
        characterCollider = GetComponent<Collider2D>();
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
        enemyGunManager = GetComponentInChildren<EnemyGunManager>();

    }

    public override void Start()
    {
        base.Start();
        
    }
}
