using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class AIStats : ScriptableObject
{
    public string enemyName;

    public float maxHealth;
    public float damage;
    public float bulletSpeed;
    public float rateOfFire;
    public float speed;
    public float engagementRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
