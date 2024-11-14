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
   /* started working on a better contract system
   [SerializeField] static public int contractAmount;
   [SerializeField] static public int counter;
   static void GetContract(GameObject contract)
   {
      GameObject[] ContractList = new GameObject[contractAmount];
      for (int i = 0; i < contractAmount; i++)
      {
         if (ContractList != null)
         {
            counter++;
         }
      }
      
      if (!(counter <= contractAmount))
      {
         Instantiate(contract);
      }


   }*/
}
