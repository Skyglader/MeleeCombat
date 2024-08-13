using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterCombatManager : MonoBehaviour
{
    public float fireRate;
    public float nextTimeToShoot;

    public UnityEvent OnShootPressed = new UnityEvent();

    public virtual void Start()
    {
        nextTimeToShoot = Time.time;
    }
    public virtual void Update()
    {
        
    }
   
}
