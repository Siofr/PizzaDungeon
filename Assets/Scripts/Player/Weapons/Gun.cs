using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SpriteRenderer))]
public class Gun : MonoBehaviour
{
    [SerializeField] Transform crosshair;
    [SerializeField] GunScriptableObject[] gunDataArray;
    [SerializeField] GameObject bullet;
    private Bullet bulletScript;
    private AudioPlayer audioPlayer;

    private float nextShot;
    private int currentWeapon;

    private SpriteRenderer weaponRenderer;

    private Quaternion currentRotation;
    private float startAngle;
    private float endAngle;

    [SerializeField] private float spread;

    private void Awake()
    {
        audioPlayer = GetComponentInParent<AudioPlayer>();
        weaponRenderer = GetComponent<SpriteRenderer>();
        weaponRenderer.sprite = gunDataArray[currentWeapon].gunSprite;

        bulletScript = bullet.GetComponent<Bullet>();
        SwapBullet();
    }

    public void Fire()
    {
        if (Time.time > nextShot)
        {
            audioPlayer.PlayAudio(gunDataArray[currentWeapon].firingNoise);
            if (gunDataArray[currentWeapon].projectiles == 1)
            {
                nextShot = Time.time + gunDataArray[currentWeapon].fireRate;

                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                newBullet.SetActive(true);
            }
            else
            {
                Vector3 targetDir = crosshair.position - transform.position;
                float targetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
                startAngle = targetAngle - spread;
                endAngle = targetAngle + spread;
                float angleSteps = (endAngle - startAngle) / gunDataArray[currentWeapon].projectiles;

                for (int i = 0; i < gunDataArray[currentWeapon].projectiles; i++)
                {
                    float currentAngle = startAngle + angleSteps * i;
                    Vector3 bulletDirection = new Vector3(0, 0, currentAngle);
                    GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                    currentRotation.eulerAngles = bulletDirection;
                    newBullet.transform.rotation = currentRotation;
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
