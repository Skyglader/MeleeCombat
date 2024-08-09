using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyAfterSetTime : MonoBehaviour
{
    public float timeToDestroy = 5f;
    void Start()
    {
        StartCoroutine(destroyBullet());
    }

    // Update is called once per frame
    public IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
