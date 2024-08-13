using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotionManager : CharacterLocomotionManager
{
    public EnemyManager enemy;
    public float rotateSpeed;


    public override void Awake()
    {
        base.Awake();
        enemy = GetComponent<EnemyManager>();
    }
    public override void Update()
    {   
        base.Update();
        HandleEnemyRotation();
    }

    private void HandleEnemyRotation()
    {
        if (!canMove)
        {
            return;
        }

        Vector2 playerLocation = (Vector2)WorldGameObjectStorage.instance.player.transform.position;
        Vector2 direction = new Vector2(playerLocation.x - transform.position.x, playerLocation.y - transform.position.y);

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion look = Quaternion.Euler(0, 0, -angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, rotateSpeed * Time.deltaTime);
        }

    }
}
