using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatManager : CharacterCombatManager
{
    [SerializeField] PlayerManager player;
    public bool stopShooting = false;

    private void Awake()
    {
        player = GetComponent<PlayerManager>();
    }

    public override void Start()
    {
        base.Start();

        fireRate = player.stats.fireRate;
    }

    public override void Update()
    {
        base.Update();
        HandleShootingAction();
    }

    private void HandleShootingAction()
    {
        if (!PlayerInputManager.instance.isShooting || stopShooting)
            return;

        if (Time.time > nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1 / fireRate;
            OnShootPressed?.Invoke();
        }

    }

}
