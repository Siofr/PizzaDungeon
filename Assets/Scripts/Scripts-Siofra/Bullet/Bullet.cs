using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    [HideInInspector] public Animator impactAnimator;
    [HideInInspector] public AnimationClip impactClip;

    [HideInInspector] public Rigidbody2D rgdBody;

    public float bulletDamage;
    public DamageType damageType;

    public SpriteRenderer bulletSprite;

    public float speed;
    public float lifetime;

    public virtual void Awake()
    {
        rgdBody = GetComponent<Rigidbody2D>();
        impactAnimator = impactEffect.GetComponent<Animator>();

        impactClip = impactAnimator.runtimeAnimatorController.animationClips[0];

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rgdBody.velocity = transform.right * speed;
    }

    public void SwapBulletDamageType(DamageType newDamageType)
    {
        damageType = newDamageType;
        bulletSprite.color = newDamageType.damageColour;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        ContactPoint2D[] contacts = new ContactPoint2D[1];

        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log(bulletDamage);
            damageable.ChangeHealth(bulletDamage, damageType);
            Destroy(gameObject);
        }
        else
        {
            GameObject newImpact = Instantiate(impactEffect, transform.position, Quaternion.identity);
            other.GetContacts(contacts);
            Vector2 collisionNormal = contacts[0].point;
            Debug.Log(collisionNormal);
            newImpact.transform.rotation = Quaternion.LookRotation(collisionNormal);
            Destroy(newImpact, impactClip.length);
            Destroy(gameObject);
        }
    }
}
