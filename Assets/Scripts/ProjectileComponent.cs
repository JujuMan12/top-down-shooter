using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    [HideInInspector] public GameObject target;

    [Header("Movement")]
    [SerializeField] private float speed = 15f;

    [Header("Ricochet")]
    [SerializeField] private LayerMask obstacleLayer;

    private void Update()
    {
        ReflectFromObstacle();
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void ReflectFromObstacle()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.5f, obstacleLayer))
        {
            Vector3 reflection = Vector3.Reflect(ray.direction, hit.normal);
            float angle = 90 - Mathf.Atan2(reflection.z, reflection.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, angle, 0f);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == target)
        {
            collider.GetComponent<WeaponFiring>().GetShot();
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
