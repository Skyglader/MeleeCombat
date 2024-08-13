using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : CharacterAnimationManager
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();

        animator = GetComponentInChildren<Animator>();
        character = GetComponent<CharacterManager>();
    }

    public override void Start()
    {
        character.statsManager.onCharacterDeath += PlayDeathAnimation;
        
    }

    private void PlayDeathAnimation(object sender, EventArgs e)
    {
        character.animationManager.animator.SetBool("IsDead", true);
    }
}
