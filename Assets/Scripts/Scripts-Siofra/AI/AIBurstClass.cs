using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBurstClass : AIBaseClass
{
    [SerializeField] private int numProjectiles;
    [SerializeField] private float bulletInterval;

    private GameObject[] bullets;

    public override void Awake()
    {
        base.Awake();
        bullets = new GameObject[numProjectiles];

        for (int i = 0; i < numProjectiles; i++)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.transform.SetParent(gameObject.transform);
            Debug.Log(newBullet);
            bullets[i] = newBullet;
        }
    }

    public override IEnumerator Attack()
    {
        for (int i = 0; i < numProjectiles; i++)
        {
            Vector3 bulletDirection = new Vector3(0, 0, (360 / numProjectiles + 0) * i);
            bullets[i].transform.position = transform.position;
            bullets[i].transform.right = aimer.transform.right;
            bullets[i].SetActive(true);

            yield return new WaitForSeconds(bulletInterval);
        }

        isAttacking = false;

        yield return null;
    }
}
