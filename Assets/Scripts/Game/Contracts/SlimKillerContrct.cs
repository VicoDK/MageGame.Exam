using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimKillerContrct : MonoBehaviour
{
    private int StartSlimeKillCount; // to track the kills the player got
    public int Prize; 

    EnemyKillStats EnemyKillStats;
    PlayerStats PlayerStat;



    void Start()
    {
        StartSlimeKillCount = EnemyKillStats.slimesKilled; //to track
        EnemyKillStats = GetComponent<EnemyKillStats>();
        PlayerStat = GetComponent<PlayerStats>();
    
    }

    void FixedUpdate()
    {
        if (EnemyKillStats.slimesKilled >= 5 + StartSlimeKillCount) //checks if player got enough kills
        {
            PlayerStat.Coin += Prize; //gives prize
            Destroy(this); //destroys contract
        }
    }
}
