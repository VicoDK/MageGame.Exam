//Credits : https://www.youtube.com/watch?v=cQ-qvFo_M40&t

using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using System.Collections;

public class AIagent : MonoBehaviour
{
    [Header("AI Path")]
    [SerializeField] private float moveSpeed; //speed of enemy 
    private AIPath path; //to store the pathing
    private Transform target; //store player local
    public Transform Foot; //enemy food local
    [SerializeField] private float stopDistanceThreshold; //how close can the enemy get to player
    private float distanceToTarget; //how far the player is from enemy
    [SerializeField] private float stopChasing; //when the enemy is too far away from player
    public float EnemyKeepInMindTime; //how long it should chase player after leaving LOS
    private float timeElapsed; //counter

    private string EnemyMode; //which mode the enemy is in

    

    [Header("Patrol")]
    public float patrolNewSpotTime; //spot to patrol to
    private GameObject PatrolSquare; //the area for patrol
    private bool running; //is the enemy moving 
    private Vector2 startPos; //start pos

    //else 
    private BasicMageAttack Scripts; //store script
    public RaycastHit2D HitFood; //raycast from food
    public EnemyHealth EnemyHealth; //enemy stats
    private bool Counting = false;
  

    private void Start()
    {

        EnemyHealth = GetComponent<EnemyHealth>();
        path = GetComponent<AIPath>(); //stores the AiPath componet
        Scripts = GetComponentInChildren<BasicMageAttack>(); //get to read some values from BasicMageAttack scriptet
        startPos = transform.position; //Stores the start pos
        PatrolSquare = GameObject.Find ("PatrolSquare"); //stores the PatrolSquare as a game object
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Foot = transform.Find("Foot").transform;
    }

    void Update()
    {

        timeElapsed -= Time.deltaTime; // timmer

        HitFood = Physics2D.Linecast(Foot.position, target.position);
        path.maxSpeed = moveSpeed; //Sets the max speed

        distanceToTarget = Vector2.Distance(transform.position, target.position); //finds the distance from enemy to player
        
        if (EnemyHealth.Alive) // checks if enemy is alive
        {
            if (distanceToTarget < stopDistanceThreshold && Scripts.Hit.collider.name == "PlayerBody" && HitFood.collider.name == "PlayerBody") //check if the enemy is too close
            {
                EnemyMode = "TooClose";

            }
            else if (distanceToTarget > stopChasing || Scripts.Hit.collider.name != "PlayerBody" ) //check if the player is too far away or if the player is in sight
            {    
  
                if  (/*timeElapsed < 0*/ Vector3.Distance(path.destination ,transform.position) < 0.7f ) // check if enemy is at the last seeing target pos
                {
                    Debug.Log("start counting ");
                    Debug.Log(timeElapsed);
                    keepInMind();
                    if (timeElapsed < 0)
                    {
                        Counting = false;
                        EnemyMode = "Patrol";
                    }
                    
                }              

            }
            else //if none of the above is true then this runs
            {
                EnemyMode = "Chase";
                //keepInMind();
            }
        }

        switch (EnemyMode)
        {
            case "Chase":
            {
                if (Scripts.Hit.collider.name == "PlayerBody" ) //only update when enemy can see player
                {
                    path.destination = target.position; //sets it path to the target pos
                    Scripts.StopShot = false; //makes it start to shoot

                }

                
                break;
            }
            case "TooClose":
            {
                path.destination = transform.position; //sets it path to its location
                Scripts.StopShot = false; //Makes the enemy shoot
                break;
            }
            case "Patrol":
            {
                if (!running) //check if enemy is patrolling
                {
                    StartCoroutine(Patrol());// start patrolling
                }
                break;
            }

        } 
    }

    void keepInMind()
    {
        
        if (Counting == false)
        {
            Counting = true;
            timeElapsed = EnemyKeepInMindTime; //make sure the timer resets
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
