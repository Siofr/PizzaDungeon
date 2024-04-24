using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBaseClass : MonoBehaviour, IDamageable
{
    private GameObject player;

    public string enemyName;
    public float speed;
    public float engagementRange;

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
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        RaycastHit2D hit;

        if (!Physics.Linecast(transform.position, player.transform.position))
        {
            agent.SetDestination(player.transform.position);
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

    public void ChangeHealth(float value, DamageType damageType)
    {
        return;
    }
}
