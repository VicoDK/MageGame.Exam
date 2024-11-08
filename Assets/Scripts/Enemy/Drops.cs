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
    public int MaxMobLoot;

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

        //random amount of gold
        int MobLoot = Random.Range(0, MaxMobLoot);

        //if this mob dosnt have any mobdrop then it dosnt run
        if (MobDropItem != null)
        {
          //runs a loop that drops coins
          for(int i = 0; i < MobLoot; i++)
          {
            //instantiates gold at the enemy's position

            GameObject mobDrop = Instantiate(MobDropItem, transform.position, Quaternion.identity);
            mobDrop.GetComponent<SlimePickup>().MobDrop();
          }

        }
  

        //is for seeing if item shuold drop
        int DropRate = Random.Range(1, 100);

        //checks if the drop rate is less than the rare drop rate
        if (DropRate < RareDropRate && RareDropItem != null && RareDropItem.Length > 0)
        {
          //picks a random object in arry
          ItemDrop = RareDropItem[Random.Range(0,RareDropItem.Length)];
          //instantiates the rare item at the enemy's position
          Instantiate(ItemDrop, transform.position, Quaternion.identity);
        }

      }
    }
}
