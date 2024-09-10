using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMoveScriptTouch : MonoBehaviour
{
    public Transform target; // The target to move towards
    public float speed = 5.0f; // The speed of the enemy

    private NavMeshAgent agent; // The NavMeshAgent component

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Check if the agent is active and on a NavMesh
        if (agent != null && agent.isOnNavMesh)
        {
            // Set the agent's speed
            agent.speed = speed;

            // Set the agent's target
            agent.SetDestination(target.position);
        }
        else
        {
            Debug.LogError("NavMeshAgent is not active or not on a NavMesh!");
        }
    }

    void Update()
    {
        // Check if the agent is active and on a NavMesh
        if (agent != null && agent.isOnNavMesh)
        {
            // Update the agent's destination
            agent.SetDestination(target.position);
        }
    }
}