using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHazard : MonoBehaviour
{
    public float value;
    public DamageType damageType;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("Damage");
            damageable.ChangeHealth(value, damageType);
        }
    }
}
