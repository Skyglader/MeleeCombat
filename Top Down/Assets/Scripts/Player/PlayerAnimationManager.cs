using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : CharacterAnimationManager
{
    public override void Awake()
    {
        base.Awake();

        animator = GetComponentInChildren<Animator>();
    }
}
