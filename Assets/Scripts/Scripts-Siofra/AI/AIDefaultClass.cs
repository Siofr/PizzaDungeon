using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDefaultClass : AIBaseClass
{
    public override IEnumerator Attack()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.right = aimer.transform.right;
        newBullet.SetActive(true);

        yield return null;
    }
}
