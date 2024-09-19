//Credits : https://www.youtube.com/watch?v=cQ-qvFo_M40&t

using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class AIagent : MonoBehaviour
{

    private AIPath path;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

    [SerializeField] private float stopDistanceThreshold;
    private float distanceToTarget;

    private void Start()
    {
        path = GetComponent<AIPath>();

    }

    void Update()
    {
        path.maxSpeed = moveSpeed;

        distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget < stopDistanceThreshold)
        {
            path.destination = transform.position;

        }
        else
        {
            path.destination = target.position;

        }


    }

}
