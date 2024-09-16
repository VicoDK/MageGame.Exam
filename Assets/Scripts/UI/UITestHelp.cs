using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestHelp : MonoBehaviour
{

    public GameObject enemy;
    public Transform spawnLocation;

    public void UseCoins()
    {
        if (PlayerStats.Coin > 10)
        {
            PlayerStats.Coin -= 10;
        }
        else
        {
            Debug.Log("Not enough coins");
        }

    }

    public void SpawnEnemy()
    {
        Instantiate(enemy,spawnLocation);
    }
}
