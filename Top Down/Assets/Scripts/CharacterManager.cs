using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public CharacterStats stats;
    public CharacterStatsManager statsManager;
    public CharacterAnimationManager animationManager;
    public Collider2D characterCollider;
    private void Awake()
    {
        
    }

    public virtual void DisableCollider()
    {
        characterCollider.enabled = false;
    }

    public virtual void EnableCollider()
    {
        characterCollider.enabled = true;
    }
}
