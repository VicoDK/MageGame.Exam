using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractsTracker : MonoBehaviour
{
   public GameObject[] Contracts; 

   private GameObject Contractschosen;


   public void ContractsCall(int ContractsNumber)
   {
      //picks a random object in arry
      Contractschosen  = Contracts[ContractsNumber];
      //instantiates the rare item at the enemy's position
      Instantiate(Contractschosen, transform.position, Quaternion.identity, this.transform);

   }
}
