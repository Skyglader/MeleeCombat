using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS
{
    public class CharacterAnimatorManager : MonoBehaviour
    {
        CharacterManager character;

       protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }
       public void UpdateAnimatorMovementParameters(float horizontalValue, float verticalValue)
       {
            character.animator.SetFloat("Horizontal", horizontalValue, 1f, Time.deltaTime * 6f);
            character.animator.SetFloat("Vertical", verticalValue, 1f, Time.deltaTime * 6f);
        }
    }
}
