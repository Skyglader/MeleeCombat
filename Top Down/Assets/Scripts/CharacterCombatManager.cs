using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterCombatManager : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] float nextTimeToShoot;

    public UnityEvent OnShootPressed = new UnityEvent();

    private void Start()
    {
        nextTimeToShoot = Time.time;
    }
    private void Update()
    {
        HandleShootingAction();
    }
    private void HandleShootingAction()
    {
        if (!PlayerInputManager.instance.isShooting)
            return;
        
        if (Time.time > nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1/fireRate;
            OnShootPressed?.Invoke();
        }

    }

}
