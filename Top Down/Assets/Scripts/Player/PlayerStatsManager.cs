using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : CharacterStatsManager
{
    public PlayerManager player;
    public override void Awake()
    {
        base.Awake();
        player = GetComponent<PlayerManager>();
    }

    public override void Start()
    {
        base.Start();
        onPlayerDeath += StopAllPlayerMovement;
    }

    private void StopAllPlayerMovement(object sender, EventArgs e)
    {
        if (player == null || !gameObject.CompareTag("Player"))
            return;

        player.playerLocomotionManager.canMove = false;

    }

    public override void DamageTarget(float damage)
    {
        base.DamageTarget(damage);

        CameraShake.instance.ShakeCamera(3, 0.2f);
    }


}
