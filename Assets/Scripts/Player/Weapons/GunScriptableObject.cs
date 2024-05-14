using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "ScriptableObjects/GunData", order = 1)]
public class GunScriptableObject : ScriptableObject
{
    public Sprite gunSprite;

    public float damage;
    public float fireRate;
    public float bulletSpeed;
    public float bulletLifetime;
    public int projectiles;
    public float spread;

    public AudioClip firingNoise;
}
