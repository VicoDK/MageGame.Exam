using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestHelp : MonoBehaviour
{

    public GameObject enemy;
    public Transform spawnLocation;

    PlayerStats PlayerStat;

    private void Start()
    {
        PlayerStat = GetComponent<PlayerStats>();
    }

    public void UseCoins()
    {
        if (PlayerStat.Coin > 10)
        {
            PlayerStat.Coin -= 10;
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
