using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class WorldCharacterEffectsManager : MonoBehaviour
    {
        public static WorldCharacterEffectsManager instance;

        [Header("Damage")]
        public TakeDamageEffect takeDamageEffect;

        [SerializeField] List<InstantCharacterEffect> instantEffects;
        public void Awake()
        {
            if (instance == null)
                instance = this;
            else 
                Destroy(gameObject);
        }

        private void GenerateEffectIDs()
        {
            for (int i =0; i < instantEffects.Count; ++i)
            {
                instantEffects[i].instantEffectID = i;
            }
        }
    }
}
