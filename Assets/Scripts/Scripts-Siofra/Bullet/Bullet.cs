using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rgdBody;

    public float bulletDamage;
    public DamageType damageType;

    public SpriteRenderer bulletSprite;

    public float speed;
    public float lifetime;

    private void Start()
    {
        rgdBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Awake()
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("Damage");
            damageable.ChangeHealth(bulletDamage, damageType);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
