using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovementManager : MonoBehaviour
{
    public BulletManager bulletManager;
    public Collider2D bulletCollider;
    public SpriteRenderer spriteRenderer;
    [SerializeField] float maxVelocity = 10;
    [SerializeField] float speedChangeTime=5f;
    [SerializeField] float scaleSpeed = 1f;
    [SerializeField] float targetScale = 1.8f;

    private bool hasCollided = false;
    private void Awake()
    {
        bulletManager = GetComponent<BulletManager>();
        bulletCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        HandleBulletMovement(); 
        HandleBulletScaling();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(bulletManager.tagName) || collision.gameObject.CompareTag("Projectile")) 
            return;


        hasCollided = true;
        
        CharacterManager character = null;
        //damageTarget
        //get character manager
        if (collision.gameObject.layer == LayerMask.NameToLayer("DamageableTarget"))
        {
            if (collision.gameObject.TryGetComponent<CharacterManager>(out character))
            {
                Debug.Log("Stopped");
                bulletManager.rb.velocity = Vector2.zero;
                spriteRenderer.enabled = false;
                bulletCollider.enabled = false;
                GameObject bulletImpact = Instantiate(bulletManager.bulletImpact, collision.ClosestPoint(transform.position), Quaternion.identity);

                TakeDamageEffect effect = ScriptableObject.CreateInstance<TakeDamageEffect>();
                effect.damage = bulletManager.damage;
                effect.ProcessEffect(character);
                Debug.Log("Damaged for " + bulletManager.damage);
            }
        }

       Destroy(gameObject);


    }
    private void HandleBulletMovement()
    {
        if (hasCollided)
        {
            return;
        }
        bulletManager.rb.velocity = Vector2.Lerp(bulletManager.rb.velocity, bulletManager.characterFacingDirection * maxVelocity, speedChangeTime);

    }

    private void HandleBulletScaling()
    {
        if (hasCollided)
        {
            return;
        }
        transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, targetScale, scaleSpeed), transform.localScale.z);
    }

}
