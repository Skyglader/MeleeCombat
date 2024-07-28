using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS
{
    public class CharacterInventoryManager : MonoBehaviour
    {
        public PlayerManager player;

        protected virtual void Awake()
        {
            player = GetComponent <PlayerManager>();  
        }
    }
}
