using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectsManager : MonoBehaviour
{
    public static WorldEffectsManager instance;

    [Header("Damage")]
    public TakeDamageEffect takeDamageEffect;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
