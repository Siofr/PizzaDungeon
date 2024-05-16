using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShotgunClass : AIBaseClass
{
    [SerializeField] private float spread;
    [SerializeField] private int numProjectiles;

    private GameObject[] bullets;

    private Quaternion currentRotation;
    private float startAngle;
    private float endAngle;

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
        float targetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        startAngle = targetAngle - spread;
        endAngle = targetAngle + spread;
        float angleSteps = (endAngle - startAngle) / numProjectiles;

        for (int i = 0; i < numProjectiles; i++)
        {
            float currentAngle = startAngle + angleSteps * i;
            Vector3 bulletDirection = new Vector3(0, 0, currentAngle);
            bullets[i].transform.position = transform.position;
            bullets[i].transform.rotation = currentRotation;
            currentRotation.eulerAngles = bulletDirection;
            bullets[i].transform.rotation = currentRotation;
            bullets[i].SetActive(true);
        }

        isAttacking = false;

        yield return null;
    }
}
