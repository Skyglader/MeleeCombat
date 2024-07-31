using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;


namespace DS
{

    public class DamageCollider : MonoBehaviour
    {
        [Header("Collider")]
        protected Collider damageCollider;
        
        [Header("Damage")]
        public float physicalDamage = 0;
        public float magicDamage = 0;

        [Header("Contact Point")]
        public Vector3 contactPoint;

        [Header("Characters Damaged")]
        protected List<CharacterManager> charactersDamaged = new List<CharacterManager>();
        private void OnTriggerEnter(Collider other)
        {
         
            CharacterManager character = other.GetComponentInParent<CharacterManager>();
            if (character != null)
            {
                contactPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

                DamageTarget(character);
                Debug.Log("Contact:" + other.gameObject.name);
            }
            Debug.Log("Detected" + other.gameObject.name);
        }

        protected virtual void DamageTarget(CharacterManager damageTarget)
        {
            if (charactersDamaged.Contains(damageTarget))
                return;
            charactersDamaged.Add(damageTarget);
            TakeDamageEffect damageEffect = Instantiate(WorldCharacterEffectsManager.instance.takeDamageEffect);
            damageEffect.physicalDamage = physicalDamage;
            damageEffect.magicDamage = magicDamage;

            damageTarget.characterEffectsManager.ProcessInstantCharacterEffect(damageEffect);
            Debug.Log("Damaged:" + damageTarget.gameObject.transform.name);
            
            
        }

        public virtual void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }
        public virtual void DisableDamageCollider()
        {
            damageCollider.enabled = false;
            charactersDamaged.Clear();
        }

    }
}
