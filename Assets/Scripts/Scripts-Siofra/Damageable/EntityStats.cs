using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour, IDamageable
{
    public float health;
    private float maxHealth;

    public DamageType currentDamageType;
    public DamageType currentResistance;
    public DamageType currentWeakness;
    public DamageType currentHealedBy;

    [SerializeField] GameObject bulletEntity;
    private Bullet bulletScript;

    public float entitySpeed;

    // Start is called before the first frame update
    void Start()
    {
        bulletScript = bulletEntity.GetComponent<Bullet>();
        bulletScript.SwapBulletDamageType(currentDamageType);
        maxHealth = health;
    }

    public void ChangeHealth(float value, DamageType damageType)
    {
        float valueMultiplier = 1.0f;

        if (currentResistance == damageType)
        {
            valueMultiplier = 0.5f;
        }

        if (currentWeakness == damageType)
        {
            valueMultiplier = 1.5f;
        }

        if (currentHealedBy == damageType)
        {
            health += value * valueMultiplier;
        }
        else
        {
            health -= value * valueMultiplier;
        }

        if (health <= 0)
        {
            Debug.Log("Entity Dead");
        }

        // Don't let player go above max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void SwapDamageType(DamageType newDamageType)
    {
        currentDamageType = newDamageType;
        bulletScript.SwapBulletDamageType(newDamageType);
    }

    public void SwapWeakness(DamageType newWeakness)
    {
        currentWeakness = newWeakness;

        if (currentResistance = newWeakness)
        {
            currentResistance = null;
        }
    }

    public void SwapResistance(DamageType newResistance)
    {
        currentResistance = newResistance;

        if (currentWeakness = newResistance)
        {
            currentWeakness = null;
        }
    }

    public void SwapHealedBy(DamageType newHealedBy)
    {
        currentHealedBy = newHealedBy;
    }
}
