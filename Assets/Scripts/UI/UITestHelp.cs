using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestHelp : MonoBehaviour
{

    public GameObject enemy;
    public GameObject mage;
    public Transform spawnLocation;

    public void SpawnEnemy()
    {
        Instantiate(enemy,spawnLocation);
    }

    public void SpawnMage()
    {
        Instantiate(mage,spawnLocation);
    }
}
