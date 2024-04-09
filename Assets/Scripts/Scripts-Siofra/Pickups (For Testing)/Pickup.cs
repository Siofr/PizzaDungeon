using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private DamageType damageType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EntityStats>().SwapDamageType(damageType);
    }
}
