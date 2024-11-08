using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Animations;

public class SlimKillerContrct : MonoBehaviour
{
    
    private int StartSlimeKillCount; // to track the kills the player got
    public int Prize;
    public GameObject itemReward; 

    public int killAmount;

    public EnemyKillStats EnemyKillStats;
    public Inventory inventory;




    void Start()
    {
        Debug.Log("1");
        EnemyKillStats = transform.parent.GetComponentInParent<EnemyKillStats>();
        StartSlimeKillCount = EnemyKillStats.slimesKilled; //to track
        inventory = GameObject.Find("CanvasG").GetComponent<Inventory>();
    
    }

    public void Update()
    {
        
        Debug.Log("test");
        if (EnemyKillStats.slimesKilled >= killAmount + StartSlimeKillCount) //checks if player got enough kills
        {
            if (Prize > 0)
            {
                inventory.coin += Prize; //gives prize
            }

            if (itemReward != null)
            {

                Inventory.Getitem(itemReward);
            }

            Destroy(this); //destroys contract
        }
    }
}
