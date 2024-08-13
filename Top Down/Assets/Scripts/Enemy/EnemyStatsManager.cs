using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsManager : CharacterStatsManager
{
    [SerializeField] EnemyManager enemy;
    public override void Awake()
    {
        base.Awake();
        enemy = GetComponent<EnemyManager>();

    }
    public override void Start()
    {
        base.Start();
        onCharacterDeath += StopAllPlayerMovement;
    }

    private void StopAllPlayerMovement(object sender, EventArgs e)
    {
        enemy.enemyLocomotionManager.canMove = false;
        enemy.enemyGunManager.stopShooting = true;

    }

    
}
