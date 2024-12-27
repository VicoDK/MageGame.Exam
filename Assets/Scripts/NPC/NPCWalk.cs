using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class NPCWalk : MonoBehaviour
{
    [System.Serializable] public class Walk
    {
        public GameObject point;
        public float Staytime;
    }

    public Walk[] walkPoints;
    AIPath path; //to store the pathing
    public float distance;
    int i = 0;

    void Start()
    {
        path = GetComponent<AIPath>();
        StartCoroutine("movment");
    }


    public IEnumerator movment()
    {
        path.destination = walkPoints[i].point.transform.position; //sets it path to the target pos

        yield return new WaitUntil(() => distance > Vector2.Distance(this.transform.position, walkPoints[i].point.transform.position));

        if (walkPoints[i].Staytime != 0 && distance> Vector2.Distance(this.transform.position, walkPoints[i].point.transform.position))
        {
            yield return new WaitForSeconds(Random.Range(walkPoints[i].Staytime-2, walkPoints[i].Staytime+2));
        }
   
        Restart();
    }

    public void Restart()
    {   
        if (i<walkPoints.Length-1)
        {
            i++;
        }
        else 
        {
            i = 0; 
        }
        StartCoroutine("movment");
    }
    

}
