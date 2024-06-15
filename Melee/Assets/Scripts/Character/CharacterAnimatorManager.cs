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

        public virtual void PlayerTargetActionAnimation(string targetAnimation, bool isPerformingAction, bool applyRootMotion = true, bool canRotate = false, bool canMove = false)
        {
            character.applyRootMotion = applyRootMotion;
            character.animator.CrossFade(targetAnimation, .2f);
            Debug.Log("Played");
            character.isPerformingAction = isPerformingAction;
            character.canRotate = canRotate;
            character.canMove = canMove;
        }
    }
}
