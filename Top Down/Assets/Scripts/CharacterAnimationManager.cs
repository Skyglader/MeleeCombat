using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
    public Animator animator;
    public CharacterManager character;
    
    public virtual void Awake()
    {

    }

    public void PlayTargetAnimation(string animationName)
    {
        animator.CrossFade(animationName, 0.3f);
    }
}
