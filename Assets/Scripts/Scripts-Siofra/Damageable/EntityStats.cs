using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityStats : MonoBehaviour, IDamageable
{
    public float health;
    private float maxHealth;

    public float dashAmount;
    [SerializeField] private float staminaRegenSpeed;

    [SerializeField] private Healthbar healthbar;
    [SerializeField] private Slider staminaBar;
    public bool hasStamina = true;

    public DamageType currentDamageType;
    public DamageType currentResistance;
    public DamageType currentWeakness;
    public DamageType currentHealedBy;

    [SerializeField] GameObject bulletEntity;
    private Bullet bulletScript;

    private DamageFlash damageFlash;

    public float entitySpeed;

    public GameObject deathScreen;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetFloat("PlayerHealth") == 0)
        {
            PlayerPrefs.SetFloat("PlayerHealth", 1.0f);
        }

        bulletScript = bulletEntity.GetComponent<Bullet>();
        bulletScript.SwapBulletDamageType(currentDamageType);

        health = health * PlayerPrefs.GetFloat("PlayerHealth");
        maxHealth = health;

        // damageFlash.GetComponent<DamageFlash>();

        Slider healthbarComponent = healthbar.GetComponent<Slider>();
        healthbarComponent.maxValue = maxHealth;
        healthbarComponent.value = maxHealth;
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
            // damageFlash.CallDamageFlash();
        }

        if (health <= 0)
        {
            deathScreen.GetComponent<DeathScreen>().ShowDeathScreen();
            gameObject.SetActive(false);
        }

        // Don't let player go above max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthbar.UpdateHealth(health);
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

    public IEnumerator Stamina()
    {
        hasStamina = false;

        staminaBar.value = 0;

        while (staminaBar.maxValue - staminaBar.value > 0.5f)
        {
            staminaBar.value = Mathf.Lerp(staminaBar.value, staminaBar.maxValue, staminaRegenSpeed * Time.deltaTime);

            yield return null;
        }

        staminaBar.value = staminaBar.maxValue;

        hasStamina = true;

        yield return null;
    }
}
