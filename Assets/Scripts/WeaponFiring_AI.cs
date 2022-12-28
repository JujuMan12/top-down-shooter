using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFiring_AI : WeaponFiring
{
    [Header("Aiming")]
    [SerializeField] private float rayDistance = 20f;
    [SerializeField] private AIController aiController;

    override protected void Update()
    {
        if (timeToFire > 0f)
        {
            timeToFire -= Time.deltaTime;
        }
        else
        {
            AimForPlayer();
        }
    }

    override public void GetShot()
    {
        gameScore.AddScore(true);
    }

    private void AimForPlayer()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance) && hit.collider.gameObject == opponent)
        {
            FireProjectile(gameObject.transform.rotation);
        }
        //else
        //{
        //    AimForObstacle();
        //}
    }

    //private void AimForObstacle()
    //{
    //    Vector3 direction = aiController.navTargets[Random.Range(0, aiController.navTargets.Length)].position - transform.position;

    //    float angle = Mathf.Atan2(direction.z, -direction.x) * Mathf.Rad2Deg - 90f;
    //    FireProjectile(Quaternion.Euler(new Vector3(0f, angle, 0f)));
    //}
}
