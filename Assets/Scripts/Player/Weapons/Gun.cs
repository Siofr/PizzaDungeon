using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Gun : MonoBehaviour
{
    [SerializeField] GunScriptableObject[] gunDataArray;
    [SerializeField] GameObject bullet;
    private Bullet bulletScript;

    private float nextShot;
    private int currentWeapon;

    private SpriteRenderer weaponRenderer;

    private void Awake()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
        weaponRenderer.sprite = gunDataArray[currentWeapon].gunSprite;

        bulletScript = bullet.GetComponent<Bullet>();
        SwapBullet();
    }

    public void Fire()
    {
        if (Time.time > nextShot)
        {
            if (gunDataArray[currentWeapon].projectiles == 1)
            {
                nextShot = Time.time + gunDataArray[currentWeapon].fireRate;

                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                newBullet.SetActive(true);
            }
            else
            {
                for (int i = 0; i < gunDataArray[currentWeapon].projectiles; i++)
                {
                    nextShot = Time.time + gunDataArray[currentWeapon].fireRate;

                    GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                    newBullet.SetActive(true);
                }
            }
        }
    }

    public void SwapWeapon(float direction)
    {
        if (direction > 0)
        {
            Debug.Log("Swap Positive");
            if (currentWeapon >= gunDataArray.Length - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon += 1;
            }
        }
        else
        {
            Debug.Log("Swap Negative");
            if (currentWeapon <= 0)
            {
                currentWeapon = gunDataArray.Length - 1;
            }
            else
            {
                currentWeapon -= 1;
            }
        }
        weaponRenderer.sprite = gunDataArray[currentWeapon].gunSprite;
        SwapBullet();
    }

    public void SwapBullet()
    {
        bulletScript.lifetime = gunDataArray[currentWeapon].bulletLifetime;
        bulletScript.speed = gunDataArray[currentWeapon].bulletSpeed;
        bulletScript.bulletDamage = gunDataArray[currentWeapon].damage;
    }
}
