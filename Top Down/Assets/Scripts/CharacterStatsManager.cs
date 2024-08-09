using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public event EventHandler onPlayerDeath;
    public float health = 1;
    public float maxHealth;
    public SpriteRenderer playerRenderer;
    public CharacterManager character;
    public Color originalColor;
    public float Health
    {
        get { return health; }
        set 
        {
            health = value; 

        }
    }

    public virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = playerRenderer.color;
    }

    public virtual void Start()
    {
        Health = character.stats.vitality * 10;
        Debug.Log("Health: " + Health);
        maxHealth = Health;
        onPlayerDeath += PlayDeathAnimation;
    }

    public virtual void DamageTarget(float damage)
    {
        if (health > 0)
        {
            Health -= damage;
            StartCoroutine(FlashRed()); 
            
            if (gameObject.CompareTag("Player") && Health <= 0)
            {
                onPlayerDeath(this, EventArgs.Empty);
            }
        }
        else
        {
            Health = 0;
        }
        Debug.Log(Health);
        
    }

    private IEnumerator FlashRed()
    {
        playerRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        playerRenderer.color = originalColor;
    }

    private void PlayDeathAnimation(object sender, EventArgs e)
    {
        if (gameObject.CompareTag("Player"))
        {
            character.animationManager.PlayTargetAnimation("PlayerDeath");
        }
    }
}
