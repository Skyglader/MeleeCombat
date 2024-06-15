using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS
{
    public class CharacterSoundEffectsManager : MonoBehaviour
    {
        private AudioSource audioSource;

        protected virtual void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayRollSoundFX()
        {
            audioSource.PlayOneShot(WorldSoundEffectsManager.instance.rollSFX);
        }
    }
}
