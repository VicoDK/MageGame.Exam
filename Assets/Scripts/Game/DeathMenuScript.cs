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
    Controls controls;

    private void Start()
    {
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        Attack = GameObject.Find("PlayerBody").GetComponent<Attack>();
        pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
        controls = GameObject.Find("PlayerBody").GetComponent<Controls>();
    }

    public void Quit()
    {
        Application.Quit(); // to quit game
    }

    public void Restart()
    {
        // Reset player stats and reload the scene
        PlayerStat.Alive = true;
        controls.AttackReady  = true;
        Time.timeScale = 1;
        pInput.ActivateInput();

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        
    }

}
