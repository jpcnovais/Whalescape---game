using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{


    public Transform player;
    public NavMeshAgent agent;

    public LayerMask whatIsPlayer, whatIsGround;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange)
        {
            Patroling();
        }
        if (playerInSightRange)
        {
            ChasePlayer();
        }


    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        { }
        agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        Debug.Log("entrou na area");

    }


}
