using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    PlayerStats PlayerStat;
    Attack Attack;

    private void Start()
    {
        PlayerStat = GetComponent<PlayerStats>();
        Attack = GetComponent<Attack>();
    }

    public void Quit()
    {
        Application.Quit(); // to quit game
    }

    public void Restart()
    {
        // Reset player stats and reload the scene
        PlayerStat.Alive = true;
        Attack.AttackReady = true;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        
    }

}
