using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterStatsManager : MonoBehaviour
{
    public event EventHandler onCharacterDeath;
    public float health = 1;
    public float maxHealth;
    public SpriteRenderer playerRenderer;
    public CharacterManager character;
    public Color originalColor;

    public bool isDead;
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
        onCharacterDeath += PlayDeathAnimation;
    }

    public virtual void DamageTarget(float damage)
    {
        if (health > 0)
        {
            Health -= damage;
            StartCoroutine(FlashRed()); 
            
            if (Health <= 0)
            {
                onCharacterDeath(this, EventArgs.Empty);
                isDead = true;
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
        yield return new WaitForSeconds(0.1f);
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
