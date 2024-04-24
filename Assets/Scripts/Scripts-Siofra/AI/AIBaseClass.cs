using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBaseClass : MonoBehaviour, IDamageable
{
    private GameObject player;

    public float health;
    private float maxHealth;

    public string enemyName;
    public float damage;
    public float bulletSpeed;
    public float rateOfFire;
    public float speed;
    public float engagementRange;
    private float nextShot;

    public GameObject bullet;
    private Bullet bulletScript;

    private NavMeshAgent agent;

    public DamageType currentDamageType;
    public DamageType currentResistance;
    public DamageType currentWeakness;
    public DamageType currentHealedBy;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = speed;

        player = GameObject.FindWithTag("Player");

        maxHealth = health;

        bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.bulletDamage = damage; 
        bulletScript.speed = bulletSpeed;
        bulletScript.SwapBulletDamageType(currentDamageType);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, player.transform.position);
        Movement();
    }

    void Movement()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position);
        if (hit.collider.tag != "Player")
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            Attack();
            if (Vector3.Distance(player.transform.position, transform.position) <= engagementRange)
            {
                agent.SetDestination(transform.position);
            }
            else
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }

    void Attack()
    {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + rateOfFire;

            Vector2 playerPosition = player.transform.position;
            Vector2 aimDirection = (playerPosition - new Vector2(transform.position.x, transform.position.y)).normalized;

            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            Quaternion aimAngle = new Quaternion(0, 0, angle, 0);

            GameObject newBullet = Instantiate(bullet, transform.position, aimAngle);
            newBullet.SetActive(true);
        }
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
            Destroy(gameObject);
        }

        // Don't let player go above max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
