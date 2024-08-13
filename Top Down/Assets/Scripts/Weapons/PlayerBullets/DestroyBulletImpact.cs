using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletImpact : MonoBehaviour
{
    public void DeleteImpactAnimation()
    {
        Destroy(gameObject.transform.parent.gameObject); 
    }
}
