using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGunScript : MonoBehaviour
{
    public Bullet_WeaponItem gun;
    //public CharacterManager player;
    public float dmgPerLevel = 2f;
    public float nextFireRate = 0f;
    public float fireRate = 3f;

    private void Awake()
    {
        //player = GetComponent<CharacterManager>();
    }
    private void Start()
    {
        // subscribe to unity event to shoot bullets from every gun
    }

    private void ShootBullet()
    {
        // get bullet prefab from Bullet_WeaponItem
        // instantiate(bulle t) and set damage
        GameObject bullet = Instantiate(gun.bulletPrefab, transform.position, transform.rotation);
        BulletManager bulletManager = bullet.GetComponent<BulletManager>();
        bulletManager.damage = 3 * dmgPerLevel;
        bulletManager.bulletInfo = gun;
        bulletManager.tagName = this.gameObject.tag;


        bulletManager.characterFacingDirection = (Vector2)gameObject.transform.up;

    }

    private void Update()
    {
        if (Time.time > nextFireRate)
        {
            nextFireRate = Time.time + (1 / fireRate);
            ShootBullet();
        }
    }
}
