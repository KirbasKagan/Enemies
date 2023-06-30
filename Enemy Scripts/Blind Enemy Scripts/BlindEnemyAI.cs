using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlindEnemyAI : MonoBehaviour
{
    //Transform
    [SerializeField] private Transform target;
    
    //Range Area
    [SerializeField] private float hearRange = 10f;
    [SerializeField] private float walkRange = 1000f;
    [SerializeField] private float triggerRange = 2f;
    
    //Speed Limits
    [SerializeField] private float turnSpeed = 20f;
    [SerializeField] private float petrollingSpeed = 10f;
    [SerializeField] private float chaseSpeed = 20f;
    [SerializeField] private float triggeredSpeed = 30f;
    
    //Weapons
    private Weapons _weapons;

    private NavMeshAgent _navMeshAgent;
    private float targetToDestince = Mathf.Infinity;
    
    private bool isHear = false;
    private bool isTriggered = false;


    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _weapons = FindObjectOfType<Weapons>();
    }

    private void Update()
    {
        BlindEnemyAICommends();
    }

    private void BlindEnemyAICommends()
    {
        targetToDestince = Vector3.Distance(target.position, transform.position);

        if (!isHear)
        {
            Petrolling();
        }

        if (isHear && !isTriggered)
        {
            EngageTarget();
        }
        else if (isHear && isTriggered)
        {
            EngageTarget();
        }
        
        if (targetToDestince <= hearRange && (Input.GetKey(KeyCode.LeftShift) || _weapons.isShooted))
        {
            if (targetToDestince <= triggerRange)
            {
                isTriggered = true;
                _navMeshAgent.speed = triggeredSpeed;
            }
            isHear = true;
        }
        else if (targetToDestince <= hearRange && (!Input.GetKey(KeyCode.LeftShift) || !_weapons.isShooted))
        {
            if (!isTriggered)
            {
                isHear = false;
            }
        }

        if (targetToDestince >= hearRange)
        {
            isHear = false;
        }
    }

    public void OnTakenDamage()
    {
        isHear = true;
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
        _navMeshAgent.speed = chaseSpeed;
        _navMeshAgent.SetDestination(target.position);
    }

    public void ChaseObjects(Transform transform)
    {
        _navMeshAgent.SetDestination(transform.position);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,hearRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,triggerRange);
    }
}
