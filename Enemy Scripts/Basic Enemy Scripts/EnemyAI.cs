using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] public Transform target;
    
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float walkRange = 1000f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float petrollingSpeed = 5f;
    [SerializeField] private float provekedSpeed = 7f;

    private NavMeshAgent _navMeshAgent;
    private float targetToDestince = Mathf.Infinity;
    private bool isProvoked = false;
    private bool isPetrolling = true;


    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
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
        else if (targetToDestince <= chaseRange)
        {
            isProvoked = true;
            isPetrolling = false;
        }
        else if (targetToDestince >= chaseRange)
        {
            isProvoked = false;
            isPetrolling = true;
        }
    }

    public void OnTakenDamage()
    {
        isProvoked = true;
        isPetrolling = false;
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
        float x = Random.Range(-walkRange,walkRange);
        float z = Random.Range(-walkRange,walkRange);
        
        GetComponent<Animator>().SetBool("IsMove", false);
        
        _navMeshAgent.speed = petrollingSpeed;
        _navMeshAgent.SetDestination(new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z));
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack",false);
        GetComponent<Animator>().SetBool("IsMove", true);
        
        _navMeshAgent.speed = provekedSpeed;
        _navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,chaseRange);
    }
}
