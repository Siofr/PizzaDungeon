using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDefaultClass : AIBaseClass
{
    [SerializeField] private int bulletsToPool;
    private GameObject[] bullets;

    private void Start()
    {
        base.Awake();
        bullets = new GameObject[bulletsToPool];

        for (int i = 0; i < bulletsToPool; i++)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.transform.SetParent(gameObject.transform);
            Debug.Log(newBullet);
            bullets[i] = newBullet;
        }
    }

    public override IEnumerator Attack()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = aimer.transform.position;
                bullets[i].transform.right = aimer.transform.right;
                bullets[i].SetActive(true);
                break;
            }
        }

        isAttacking = false;

        yield return null;
    }
}
