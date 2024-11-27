using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    private PlayerStats PlayerStat;
    Inventory inventory;
    Attack Attack;
    Controls controls;

    static public float CoinAmount = 0;

    private void Start()
    {
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        Attack = GameObject.Find("PlayerBody").GetComponent<Attack>();
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        controls = GameObject.Find("PlayerBody").GetComponent<Controls>();
    }

    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player") )
        {

            // Reset player stats and reload the scene
            PlayerStat.Alive = true;
            controls.AttackReady  = true;
            CoinAmount = inventory.coin; // make better save system
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);

        }


    }
}
