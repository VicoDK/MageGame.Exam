using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyKillTracker : MonoBehaviour
{
    public String EnemyType; //name of enemy

    void OnDestroy() //runs when destoyed
    {

      if(gameObject.scene.isLoaded) //safty
      {
        
        switch (EnemyType)//checks enemy types
        {
        case "Slime":
            EnemyKillStats.SlimesKilled++; //slime killed therefore slimeskilled start plused 
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
