using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS
{
    public class CharacterEffectsManager : MonoBehaviour
    {

        CharacterManager character;

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }
        public virtual void ProcessInstantCharacterEffect(InstantCharacterEffect effect)
        {
            effect.ProcessEffect(character);
        }
    }
}
