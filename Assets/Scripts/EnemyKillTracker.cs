using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyKillTracker : MonoBehaviour
{
    public String enemyType; //name of enemy

    EnemyKillStats EnemyKillStats;

    private void Start()
    {
        EnemyKillStats = GetComponent<EnemyKillStats>();
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
/*        case 4:
            
            break;
        case 3:
            
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
