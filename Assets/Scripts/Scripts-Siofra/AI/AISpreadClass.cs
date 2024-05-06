using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpreadClass : AIBaseClass
{
    private Quaternion currentRotation;
    public float chargeTime;
    public float maxGrowthMultiplier;
    private Vector3 originalSize;

    public override void Awake()
    {
        base.Awake();
        originalSize = transform.localScale;
    }

    public override IEnumerator Attack()
    {
        float timeToShoot = Time.time + chargeTime;

        while (Time.time < timeToShoot)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * maxGrowthMultiplier, 0.5f * Time.deltaTime);
            yield return null;
        }

        for (int i = 0; i < 8; i++)
        {
            Vector3 bulletDirection = new Vector3(0, 0, 45 * i);
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            currentRotation.eulerAngles = bulletDirection;
            newBullet.transform.rotation = currentRotation;
            newBullet.SetActive(true);
        }

        while (Vector3.Distance(transform.localScale, originalSize) > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalSize, 3f * Time.deltaTime);

            yield return null;
        }
    }
}
