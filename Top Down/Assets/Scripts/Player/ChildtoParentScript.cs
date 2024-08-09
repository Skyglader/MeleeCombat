using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildtoParentScript : MonoBehaviour
{
    public CharacterManager character;

    private void Awake()
    {
        character = GetComponentInParent<CharacterManager>();
    }

    public void ChangeCharacterColliderState(int activate)
    {
        if (activate == 1)
        {
            character.EnableCollider();
        }
        else
        {
            character.DisableCollider();
        }
    }
}
