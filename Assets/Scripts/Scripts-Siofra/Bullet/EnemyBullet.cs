using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{

    public override void Awake()
    {
        rgdBody = GetComponent<Rigidbody2D>();
        impactAnimator = impactEffect.GetComponent<Animator>();

        impactClip = impactAnimator.runtimeAnimatorController.animationClips[0];
    }

    private void OnEnable()
    {
        StartCoroutine(DeathTimer());
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        ContactPoint2D[] contacts = new ContactPoint2D[1];

        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ChangeHealth(bulletDamage, damageType);
            gameObject.SetActive(false);
        }
        else
        {
            GameObject newImpact = Instantiate(impactEffect, transform.position, Quaternion.identity);
            other.GetContacts(contacts);
            Vector2 collisionNormal = contacts[0].point;
            newImpact.transform.rotation = Quaternion.LookRotation(collisionNormal);
            Destroy(newImpact, impactClip.length);
            gameObject.SetActive(false);
        }
    }

    public IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }
}
