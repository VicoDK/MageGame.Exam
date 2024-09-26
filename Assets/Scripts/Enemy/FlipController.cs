using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{
    //to track the last pos 
    private Vector3 previousPosition;

    void Start()
    {
        //get the first pos
        previousPosition = transform.position;
    }

    void Update()
    {   
        //set the currentPosition to the object location
        Vector3 currentPosition = transform.position;
        //stores the diffens between currentPosition and previousPosition
        Vector3 movement = currentPosition - previousPosition;

        //check which way it is moving and sets the scale accordingly to which way it moving 
        if (movement.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else if (movement.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
        }

        //set it currentPosition to previousPosition
        previousPosition = currentPosition;
    }
}
