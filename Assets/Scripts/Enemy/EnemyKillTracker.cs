using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyKillTracker : MonoBehaviour
{
    public String enemyType; //name of enemy

    private EnemyKillStats EnemyKillStats;

    void Start()
    {
        EnemyKillStats = GameObject.Find("ContactTracker").gameObject.GetComponent<EnemyKillStats>();
    }

    void OnDestroy() //runs when destoyed
    {

      if(gameObject.scene.isLoaded) //safty
      {
        
        switch (enemyType)//checks enemy types
        {
        case "Slime":
            EnemyKillStats.slimesKilled++; //slime killed therefore slimeskilled start plused 
            break;
        case "Test":
        Debug.Log("test død");
            break;
        /*case 3:
            
            break;
        case 2:
            
            break;
        case 1:
            
            break;
*/        default:

            break;
        }



      }
    }
}
