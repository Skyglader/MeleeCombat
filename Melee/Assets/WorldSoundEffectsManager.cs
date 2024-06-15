using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{


    public class WorldSoundEffectsManager : MonoBehaviour
    {

        public static WorldSoundEffectsManager instance;
        public AudioClip rollSFX;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else 
                Destroy(gameObject);
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
