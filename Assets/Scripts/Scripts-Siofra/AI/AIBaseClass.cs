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
    public float nextShot;

    private DamageFlash damageFlash;

    public GameObject bullet;
    private Bullet bulletScript;

    private NavMeshAgent agent;
    private int playerLayerMask = 1 << 3;

    public Transform aimer;
    [HideInInspector] public Vector3 targetDir;

    [HideInInspector] public bool isAttacking;

    [SerializeField] private GameObject itemDrop;

    public DamageType currentDamageType;
    public DamageType currentResistance;
    public DamageType currentWeakness;
    public DamageType currentHealedBy;

    [SerializeField] private GameDataManager dataManager;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        playerLayerMask = ~playerLayerMask;

        damageFlash = GetComponent<DamageFlash>();

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
    public void Update()
    {
        targetDir = player.transform.position - transform.position;
        aimer.transform.right = new Vector3(targetDir.x, targetDir.y, 0);

        Debug.DrawLine(transform.position, player.transform.position);
        Movement();
    }

    public virtual void Movement()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position);
        if (hit.collider.tag != "Player")
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            if (Time.time > nextShot && !isAttacking)
            {
                nextShot = Time.time + rateOfFire;
                isAttacking = true;
                StartCoroutine(Attack());
            }
            
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

    public virtual IEnumerator Attack() { yield return null; }

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

        damageFlash.CallDamageFlash();

        if (health <= 0)
        {
            itemDrop.transform.position = transform.position;
            dataManager.enemiesKilledCurrentSession++;
            itemDrop.SetActive(true);
            Destroy(gameObject);
        }

        // Don't let player go above max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
