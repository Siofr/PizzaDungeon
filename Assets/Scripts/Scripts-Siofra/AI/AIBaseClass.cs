using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBaseClass : MonoBehaviour, IDamageable
{
    [HideInInspector] public GameObject player;

    public float health;
    private float maxHealth;

    public string enemyName;
    public float damage;
    public float bulletSpeed;
    public float rateOfFire;
    public float speed;
    public float engagementRange;
    public float aggroRange;
    public float nextShot;

    private bool spottedPlayer = false;

    private DamageFlash damageFlash;

    public GameObject bullet;
    private Bullet bulletScript;

    private NavMeshAgent agent;
    private int playerLayerMask = 1 << 3;

    public Transform aimer;
    [HideInInspector] public Vector3 targetDir;

    [HideInInspector] public bool isAttacking;
    private bool isKnocked = false;

    [SerializeField] private GameObject itemDrop;

    public DamageType currentDamageType;
    public DamageType currentResistance;
    public DamageType currentWeakness;
    public DamageType currentHealedBy;

    private Animator anim;

    [SerializeField] private GameDataManager dataManager;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        if (PlayerPrefs.GetFloat("EnemyHealth") == 0)
        {
            PlayerPrefs.SetFloat("EnemyHealth", 1.0f);
        }
        playerLayerMask = ~playerLayerMask;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        damageFlash = GetComponent<DamageFlash>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = speed;

        player = GameObject.FindWithTag("Player");

        health = health * PlayerPrefs.GetFloat("EnemyHealth");
        maxHealth = health;

        bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.bulletDamage = damage; 
        bulletScript.speed = bulletSpeed;
        bulletScript.SwapBulletDamageType(currentDamageType);
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log(health);
        targetDir = player.transform.position - transform.position;
        aimer.transform.right = new Vector3(targetDir.x, targetDir.y, 0);

        Movement();
    }

    public virtual void Movement()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position);
        if (hit.collider.tag != "Player" && spottedPlayer)
        {
            agent.SetDestination(player.transform.position);
            anim.SetBool("isMoving", true);
        }
        else if (hit.collider.tag == "Player" && (Vector3.Distance(player.transform.position, transform.position) <= aggroRange || spottedPlayer))
        {
            spottedPlayer = true;
            if (Time.time > nextShot && !isAttacking)
            {
                nextShot = Time.time + rateOfFire;
                isAttacking = true;
                StartCoroutine(Attack());
            }
            
            if (Vector3.Distance(player.transform.position, transform.position) <= engagementRange)
            {
                agent.SetDestination(transform.position);
                anim.SetBool("isMoving", false);
            }
            else
            {
                agent.SetDestination(player.transform.position);
                anim.SetBool("isMoving", true);
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
            Debug.Log(value * valueMultiplier);
            health -= value * valueMultiplier;
        }

        damageFlash.CallDamageFlash();

        if (health <= 0)
        {
            itemDrop.transform.position = transform.position;
            dataManager.enemiesKilledCurrentSession++;
            itemDrop.SetActive(true);
            agent.enabled = false;
            StopAllCoroutines();
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Vector3 bulletPosition = other.gameObject.transform.position;
            StartCoroutine(FakeForce(bulletPosition));
        }
    }

    private IEnumerator FakeForce(Vector3 bulletPosition)
    {
        var direction = (bulletPosition - transform.position).normalized;
        Vector3 forcePosition = transform.position + -direction * 1.25f;
        float loopStart = Time.time;
        float loopEnd = loopStart + 0.25f;

        while (Time.time < loopEnd && gameObject != null)
        {
            agent.SetDestination(forcePosition);
            yield return null;
        }

        yield return null;
    }
}
