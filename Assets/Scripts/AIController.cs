using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [HideInInspector] private Transform navTarget;

    [Header("Navigation")]
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] public Transform[] navTargets;
    [SerializeField] private Transform player;

    private void Start()
    {
        UpdateDestination();
    }

    private void Update()
    {
        RotateToPlayer();
    }

    private void FixedUpdate()
    {
        if (navMeshAgent.remainingDistance <= 1f)
        {
            UpdateDestination();
        }
    }

    public void SetNavTarget(Transform target)
    {
        navTarget = target;
    }

    private void RotateToPlayer()
    {
        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.z, -direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
    }

    private void UpdateDestination()
    {
        navTarget = navTargets[Random.Range(0, navTargets.Length)];
        navMeshAgent.destination = navTarget.position;
    }
}
