using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeBulletManager : MonoBehaviour, BulletInterface
{
    [Header("Initializations")]
    public Rigidbody2D rb;
    public EnemyGunManager enemyGunManager;
    public SpriteRenderer spriteRenderer;
    public Collider2D bulletCollider;
    public string tagName;
    public GameObject bulletImpactPrefab;

    [Header("Animation")]
    public Animator animator;
    [SerializeField] float chargingClipLength;
    [SerializeField] float setSpeed;
    private AnimationClip clip;

    [Header("Bullet Stats")]
    [SerializeField] float bulletDamage;

    [Header("Bullet Speed")]
    [SerializeField] float maxVelocity = 10;

    [Header("Bullet Size")]
    [SerializeField] float targetScale = 1.8f;
    [SerializeField] float scaleSpeed = 1f;

    [Header("Booleans")]
    public bool hasCollided = false;
    public bool fired = false;

    [Header("Charge Time")]
    [SerializeField] float chargeDuration;
    [SerializeField] float timeElapsed;
    [SerializeField] float timeUntilRelease;


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        bulletCollider = GetComponentInChildren<Collider2D>();
        UpdateAnimClipTimes();
    }

    public void Start()
    {
        timeElapsed = Time.time;
        timeUntilRelease = Time.time + chargeDuration;
    }

    private void Update()
    {
        if (timeUntilRelease <= timeElapsed)
        {
            HandleBulletMovement();
            transform.SetParent(null);

            if (enemyGunManager != null && !fired)
            {
                fired = true;
                StartCoroutine(resetCooldown());
                
            }
            
        }
        timeElapsed = Time.time;
  

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName) || collision.gameObject.CompareTag("Projectile"))
            return;


        hasCollided = true;

        CharacterManager character = null;
        //damageTarget
        //get character manager
        if (collision.gameObject.layer == LayerMask.NameToLayer("DamageableTarget"))
        {
            if (collision.gameObject.TryGetComponent<CharacterManager>(out character))
            {

                rb.velocity = Vector2.zero;
                spriteRenderer.enabled = false;
                bulletCollider.enabled = false;
                GameObject bulletImpact = Instantiate(bulletImpactPrefab, collision.ClosestPoint(transform.position), Quaternion.identity);

                TakeDamageEffect effect = ScriptableObject.CreateInstance<TakeDamageEffect>();
                effect.damage = bulletDamage;
                effect.ProcessEffect(character);
                Debug.Log("Damaged for " + bulletDamage);
            }
            Destroy(gameObject, 2f);
        }
    }

    public void initializeBullet(Bullet_WeaponItem weaponItem, GameObject gunParent, string parentTag)
    {
        if (gunParent.TryGetComponent<EnemyGunManager>(out enemyGunManager))
        {
            enemyGunManager.stopShooting = true;
        }

        EnemyChargeBullet bullet = weaponItem as EnemyChargeBullet;

        
        transform.SetParent(gunParent.transform, true);
        tagName = parentTag;
        chargeDuration = bullet.chargeDuration;
        maxVelocity = bullet.moveSpeed;
        bulletDamage = bullet.baseDmg;
        bulletImpactPrefab = bullet.impactPrefab;

        setSpeed = chargingClipLength / chargeDuration;
        animator.SetBool("IsCharging", true);
        animator.speed = setSpeed;
       

    }

    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "BulletChargingAnim")
            {
                chargingClipLength = clip.length;
            }
        }
    }

    private void HandleBulletMovement()
    {
        if (hasCollided)
        {
            return;
        }
        HandleBulletScaling();
        rb.velocity = transform.up * maxVelocity;
    }

    private void HandleBulletScaling()
    {
        if (hasCollided)
        {
            return;
        }
        transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, targetScale, scaleSpeed), transform.localScale.z);
    }

    private IEnumerator resetCooldown()
    {
        animator.speed = 1;
        yield return new WaitForSeconds(0.25f);

        enemyGunManager.stopShooting = false;
    }

    
}
