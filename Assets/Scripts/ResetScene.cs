using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    private PlayerStats PlayerStat;
    Attack Attack;

    private void Start()
    {
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        Attack = GameObject.Find("PlayerBody").GetComponent<Attack>();
    }

    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player") )
        {

            // Reset player stats and reload the scene
            PlayerStat.Alive = true;
            Attack.AttackReady = true;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);

        }


    }
}
