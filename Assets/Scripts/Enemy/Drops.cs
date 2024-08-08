using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    //enemy position reference
    public Transform Enemy;

    //gold objects
    public GameObject coin;

    //max gold drop for enemy
    public int MaxCoins;

    //bone, slime or something else
    public GameObject MobDropItem;

    //rare stuff like skull, gems or something else
    public GameObject[] RareDropItem;
    private GameObject ItemDrop;
    
    //drop rate for rare items
    public int RareDropRate;

    
    //runs on destroy
    void OnDestroy()
    {
      //checks if the scene is loaded
      if(gameObject.scene.isLoaded)
      {
        //random amount of gold
        int CoinCount = Random.Range(1, MaxCoins);

        //runs a loop that drops coins
        for(int i = 0; i < CoinCount; i++)
        {
          //instantiates gold at the enemy's position
          Instantiate(coin, transform.position, Quaternion.identity);
        }

        //is for seeing if item shuold drop
        int DropRate = Random.Range(1, 100);

        //checks if the drop rate is less than the rare drop rate
        if (DropRate < RareDropRate)
        {
          //picks a random object in arry
          ItemDrop = RareDropItem[Random.Range(0,RareDropItem.Length)];
          //instantiates the rare item at the enemy's position
          Instantiate(ItemDrop, transform.position, Quaternion.identity);
        }

      }
    }
}
