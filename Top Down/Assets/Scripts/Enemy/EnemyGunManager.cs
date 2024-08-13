using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGunManager : MonoBehaviour
{
    public Bullet_WeaponItem bulletStats;
    public CharacterManager characterManager;
    public bool stopShooting = false;


    public float fireRate = 3;
    public float nextTimeToShoot;

    private void Awake()
    {
        characterManager = GetComponentInParent<CharacterManager>();
    }
    private void Start()
    {
        nextTimeToShoot = Time.time;
        

    }
    private void Update()
    {
        if (!stopShooting && Time.time > nextTimeToShoot)
        {
            SpawnBullet();
            nextTimeToShoot = Time.time + 1 / fireRate;
        }
    }
    public void SpawnBullet()
    {
        if (characterManager.statsManager.isDead == true)
        {
            return;
        }
        GameObject bullet = Instantiate(bulletStats.bulletPrefab, transform.position, transform.rotation);
        BulletInterface bulletScript = bullet.GetComponent<BulletInterface>();
        bulletScript.initializeBullet(bulletStats, gameObject, gameObject.tag);
    }
}
