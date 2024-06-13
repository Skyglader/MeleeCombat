using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DS
{
    public class CharacterManager : MonoBehaviour
    {
        public CharacterController characterController;
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);

            characterController = GetComponent<CharacterController>();
        }

        protected virtual void Update()
        {

        }

        protected virtual void LateUpdate()
        {
            
        }
    }
}

