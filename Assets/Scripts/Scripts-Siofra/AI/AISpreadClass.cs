using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpreadClass : AIBaseClass
{
    private Quaternion currentRotation;
    public float chargeTime;
    public float maxGrowthMultiplier;
    private Vector3 originalSize;
    private GameObject[] bullets;
    [SerializeField] private GameObject spriteObject;
    [SerializeField] private int numProjectiles;

    public override void Awake()
    {
        base.Awake();
        bullets = new GameObject[numProjectiles];
        originalSize = spriteObject.transform.localScale;
        
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
        float timeToShoot = Time.time + chargeTime;

        while (Vector3.Distance(spriteObject.transform.localScale, originalSize * maxGrowthMultiplier) > 0.1)
        {
            Debug.Log("Loop 1");
            spriteObject.transform.localScale = Vector3.Lerp(spriteObject.transform.localScale, transform.localScale * maxGrowthMultiplier, 3f * Time.deltaTime);
            yield return null;
        }

        for (int i = 0; i < numProjectiles; i++)
        {
            Vector3 bulletDirection = new Vector3(0, 0, (360 / numProjectiles + 0) * i);
            currentRotation.eulerAngles = bulletDirection;
            bullets[i].transform.position = transform.position;
            bullets[i].transform.rotation = currentRotation;
            bullets[i].SetActive(true);
        }

        while (Vector3.Distance(spriteObject.transform.localScale, originalSize) > 0.1)
        {
            Debug.Log("Loop 2");
            spriteObject.transform.localScale = Vector3.Lerp(spriteObject.transform.localScale, originalSize, 10f * Time.deltaTime);
            yield return null;
        }

        isAttacking = false;
    }
}
