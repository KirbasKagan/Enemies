using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class DeafEnemyAI : MonoBehaviour
{
    //FieldOfView
    [SerializeField] public float radius;
    [Range(0,360)]
    [SerializeField] public float angle;

    [SerializeField] public GameObject playerRef;

    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstructionMask;

    [SerializeField] public bool canSeePlayer;

    //Movement
    [SerializeField] public Transform target;
    private NavMeshAgent _navMeshAgent;
    private bool isProvoked = false;
    private bool isPetrolling = true;
    private float targetToDestince = Mathf.Infinity;
    [SerializeField] private float petrollingSpeed = 1;
    [SerializeField] private float provekedSpeed = 3;
    [SerializeField] private float walkRange = 1000f;
    [SerializeField] private float turnSpeed = 5f;


    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(FOVRoutine());
    }
    
    private void Update()
    {
        targetToDestince = Vector3.Distance(target.position, transform.position);

        if (!isProvoked && isPetrolling)
        {
            Petrolling();
        }
        if (isProvoked && !isPetrolling)
        {
            EngageTarget();
            isProvoked = false;
        }
        else if (canSeePlayer)
        {
            isProvoked = true;
            isPetrolling = false;
        }
        else if (!canSeePlayer)
        {
            isProvoked = false;
            isPetrolling = true;
        }
    }
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    
    public void OnTakenDamage()
    {
        isProvoked = true;
        isPetrolling = false;
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    isPetrolling = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
    
    void EngageTarget()
    {
        FaceTarget();
        
        if (targetToDestince >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (targetToDestince <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void Petrolling()
    {
        float x = Random.Range(-walkRange, walkRange);
        float z = Random.Range(-walkRange,walkRange);
        
        _navMeshAgent.speed = petrollingSpeed;
        _navMeshAgent.SetDestination(new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z));
    }

    private void ChaseTarget()
    {
        _navMeshAgent.speed = provekedSpeed;
        _navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log("Attacked");
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

}
