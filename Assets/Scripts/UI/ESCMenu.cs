using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ESCMenu : MonoBehaviour
{
    public GameObject EscMenu;
    private bool Aktive;
     PlayerInput  pInput;


    PlayerStats PlayerStat;
    Movment movement;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        movement = GameObject.Find("PlayerBody").GetComponent<Movment>();
        pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (pInput.actions["Escape"].WasPressedThisFrame() && !Aktive && PlayerStat.Alive)
        {
            EscMenu.SetActive(true);
            Aktive = true;
            Time.timeScale = 0;
            movement.canMove = false;


        }
        else if (pInput.actions["Escape"].WasPressedThisFrame() && Aktive && PlayerStat.Alive)
        {
            EscMenu.SetActive(false);
            Aktive = false;
            Time.timeScale = 1;
            movement.canMove = true;


        }
        
    }
    public void Resume()
    {
        EscMenu.SetActive(false);
        Aktive = false;
        Time.timeScale = 1;
        movement.canMove = true;
    }
}
