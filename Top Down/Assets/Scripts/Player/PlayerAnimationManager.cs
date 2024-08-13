using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : CharacterAnimationManager
{
    public override void Awake()
    {
        base.Awake();
        animator = GetComponentInChildren<Animator>();
        character = GetComponent<CharacterManager>();

    }

    public override void Start()
    {
        base.Start();

        
    }
}
