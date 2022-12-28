using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFiring : MonoBehaviour
{
    [HideInInspector] protected float timeToFire;

    [Header("Projectiles")]
    [SerializeField] private Transform weapon;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireCooldown = 0.5f;

    [Header("Score")]
    [SerializeField] protected GameScore gameScore;
    [SerializeField] protected GameObject opponent;

    virtual protected void Update()
    {
        if (timeToFire > 0f)
        {
            timeToFire -= Time.deltaTime;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile(gameObject.transform.rotation);
        }
    }

    protected void FireProjectile(Quaternion direction)
    {
        GameObject projectileGO = Instantiate(projectilePrefab, weapon.position, direction);
        ProjectileComponent projectile = projectileGO.GetComponent<ProjectileComponent>();
        projectile.target = opponent;

        timeToFire = fireCooldown;
    }

    virtual public void GetShot()
    {
        gameScore.AddScore(false);
    }
}
