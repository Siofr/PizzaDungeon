using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageType", menuName = "ScriptableObjects/DamageType", order = 2)]
public class DamageType : ScriptableObject
{
    public GameObject statusEffectContainer;
    public Color damageColour;

    public void StatusEffect(GameObject target)
    {

    }
}
