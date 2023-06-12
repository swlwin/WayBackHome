using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStatModifier : ScriptableObject
{
    public abstract void AffectCharacter(GameObject character, float val);
}
