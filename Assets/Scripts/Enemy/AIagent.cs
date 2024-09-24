//Credits : https://www.youtube.com/watch?v=cQ-qvFo_M40&t

using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using System.Collections;

public class AIagent : MonoBehaviour
{
    [Header("AI Path")]
    [SerializeField] private float moveSpeed;
    private AIPath path;
    private Transform target;
    [SerializeField] private float stopDistanceThreshold;
    private float distanceToTarget;
    [SerializeField] private float stopChasing;
     public float EnemyKeepInMindTime;

    [Header("Patrol")]
    public float patrolNewSpotTime;
    private GameObject PatrolSquare;
    private bool running;
    private Vector2 startPos;

    //else 
    private BasicMageAttack Scripts;

    private void Start()
    {

        path = GetComponent<AIPath>(); //stores the AiPath componet
        Scripts = GetComponentInChildren<BasicMageAttack>(); //get to read some values from BasicMageAttack scriptet
        startPos = transform.position; //Stores the start pos
        PatrolSquare = GameObject.Find ("PatrolSquare"); //stores the PatrolSquare as a game object
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        path.maxSpeed = moveSpeed; //Sets the max speed

        distanceToTarget = Vector2.Distance(transform.position, target.position); //finds the distance from enemy to player
        

        if (distanceToTarget < stopDistanceThreshold) //check if the enemy is too close
        {
            path.destination = transform.position; //sets it path to its location
            Scripts.StopShot = false; //Makes the enemy shoot

        }
        else if (distanceToTarget > stopChasing || Scripts.Hit.collider.name != "PlayerBody") //check if the player is too far away or if the player is in sight
        {
            StartCoroutine(KeepPlayerInMind()); //starts a IEnumerator
            
            

        }
        else //if none of the above is true then this runs
        {
            path.destination = target.position; //sets it path to the target pos
            Scripts.StopShot = false; //makes it start to shoot
            
        }

        



    }

    IEnumerator KeepPlayerInMind()
    {
        yield return new WaitForSeconds(EnemyKeepInMindTime); //makes it wait a few second so the enemy keeps the player in its mind

        //path.destination = transform.position; //sets it path to its location ****
        Scripts.StopShot = true; //stops the enemy from shooting
        if (!running)
        {
            StartCoroutine(Patrol());
        }
    }

    IEnumerator Patrol() //makes the enemy patrol
    {
        

        running = true; //make sure that this code dosnt run per fram 
        path.destination = new Vector2(startPos.x + Random.Range(-PatrolSquare.transform.localScale.x/2,PatrolSquare.transform.localScale.x/2), startPos.y + Random.Range(-PatrolSquare.transform.localScale.y/2,PatrolSquare.transform.localScale.y/2));
        //set the destination to a new vector2 and for the pos to go to, it takes the spawn lacal of enemy and the height and width and picks a ramdon point there
        yield return new WaitForSeconds(patrolNewSpotTime);//wait a few second so that enemy can reanche the point 

        running = false; //tell the script that the enemy is done moving
        
       
       

    }

}
