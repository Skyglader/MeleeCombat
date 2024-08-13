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

    public virtual void Start()
    {

    }
    public void PlayTargetAnimation(string animationName)
    {
        Debug.Log("Played");
        animator.CrossFade(animationName, 0.3f);
    }
}
