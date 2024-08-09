using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunScript : MonoBehaviour
{
    public Bullet_WeaponItem gun;
    public CharacterManager player;
    public float dmgPerLevel = 2f;
    public PlayerCombatManager playerCombatManager;
    private void Awake()
    {
        player = GetComponentInParent<CharacterManager>();
        playerCombatManager = GetComponentInParent<PlayerCombatManager>();
    }
    private void Start()
    {
        playerCombatManager.OnShootPressed.AddListener(ShootBullet);
    }

    private void ShootBullet()
    {
        Debug.Log("Called");
        // get bullet prefab from Bullet_WeaponItem
        // instantiate(bullet) and set damage
        GameObject bullet = Instantiate(gun.bulletPrefab, transform.position, player.transform.rotation);
        BulletManager bulletManager = bullet.GetComponent<BulletManager>();
        bulletManager.damage = player.stats.dmgLVL * dmgPerLevel;
        bulletManager.bulletInfo = gun;
        bulletManager.tagName = this.gameObject.tag;


        bulletManager.characterFacingDirection = (Vector2)player.transform.up;

    }
}
