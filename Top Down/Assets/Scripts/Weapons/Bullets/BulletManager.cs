using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Bullet_WeaponItem bulletInfo;
    public BulletMovementManager bulletMovementManager;
    public Rigidbody2D rb;
    public GameObject bulletImpact;
    public float damage;
    public string tagName;
    public Vector2 characterFacingDirection;

    private void Awake()
    {
        bulletMovementManager = GetComponent<BulletMovementManager>();
        rb = GetComponent<Rigidbody2D>();

        
    }

    private void Start()
    {
        bulletImpact = bulletInfo.impactPrefab;
    }
}
