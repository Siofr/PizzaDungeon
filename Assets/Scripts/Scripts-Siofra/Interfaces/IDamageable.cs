using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void ChangeHealth(float value, DamageType damageType);
}
