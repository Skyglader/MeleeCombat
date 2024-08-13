using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CharacterManager : MonoBehaviour
{
    

    public Rigidbody2D rb;
    public CharacterStats stats;
    public CharacterStatsManager statsManager;
    public CharacterAnimationManager animationManager;
    public Collider2D characterCollider;
    public virtual void Awake()
    {
        
    }

    public virtual void Start()
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

    public virtual void DestroyCharacter()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
