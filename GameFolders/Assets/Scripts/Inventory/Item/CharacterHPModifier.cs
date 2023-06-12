using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterHPModifier : CharacterStatModifier
{
    public override void AffectCharacter(GameObject character, float val)
    {
        HealthBar health = character.GetComponent<HealthBar>();
        if(health != null)
        {
            health.RestoreHealth((int) val);
        }
        Debug.Log("Add Health " + val);
    }
}
