using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DeathMenuScript : MonoBehaviour
{
    private PlayerStats PlayerStat;
    Attack Attack;
    private PlayerInput  pInput;

    private void Start()
    {
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        Attack = GameObject.Find("PlayerBody").GetComponent<Attack>();
        pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
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
        Time.timeScale = 1;
        pInput.ActivateInput();

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        
    }

}
