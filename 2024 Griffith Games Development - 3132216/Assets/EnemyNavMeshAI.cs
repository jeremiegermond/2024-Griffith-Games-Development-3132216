using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyNavMeshAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Animator animator;
    public Transform player;
    public NavMeshAgent agent;
    private bool aggro;
    public bool destinationReached;
    public float destinationThreshold;
    public float aggroTimer;
    public float patrolSpeed;
    public float aggroSpeed;

    public float currentVelocity;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        aggro = false;
        destinationReached = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the velocity of the enemy
        currentVelocity = agent.velocity.magnitude;
        // Set the speed of the animator to the velocity of the enemy
        animator.SetFloat("velocity", currentVelocity);
        if (aggro)
        {
            agent.destination = player.position;
        }

        if (aggro == false && destinationReached)
        {
            destinationReached = false;
            agent.speed = patrolSpeed;
            agent.destination = patrolPoints[Random.Range(0, patrolPoints.Length)].position;
        }

        // Check if the enemy has reached the destination
        if (Vector3.Distance(agent.destination, agent.transform.position) < destinationThreshold)
        {
            destinationReached = true;
        }
        
        // GetComponent<UnityEngine.AI.NavMeshAgent>().destination = player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aggro = true;
            agent.speed = aggroSpeed;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.destination = player.position;
            StopCoroutine("AggroTimer");
            StartCoroutine("AggroTimer");
        }
    }
    
    IEnumerator AggroTimer()
    {
        yield return new WaitForSeconds(aggroTimer);
        aggro = false;
        destinationReached = true;
    }
}
