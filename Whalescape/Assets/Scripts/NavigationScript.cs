using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    /*codigo a funcionar : https://youtu.be/u2EQtrdgfNs?si=dJCLJ7EuUmgecnAI
    public Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        
    }*/

    public Transform player;
    public NavMeshAgent agent;

    public LayerMask whatIsPlayer, whatIsGround;

    //patrulha
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //estados
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //verificar se o jogador está dentro da area de ataque
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

        //walkpoint alcançado
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //calcular um ponto aleatório
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //verificar se o ponto não vai para fora do mapa
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
