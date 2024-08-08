using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestHelp : MonoBehaviour
{

    public GameObject Enemy;
    public Transform SpawnLocation;

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
        Instantiate(Enemy,SpawnLocation);
    }
}
