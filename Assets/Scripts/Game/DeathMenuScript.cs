using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit(); // to quit game
    }

    public void Restart()
    {
        // Reset player stats and reload the scene
        PlayerStats.Alive = true;
        Attack.AttackReady = true;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        
    }

}
