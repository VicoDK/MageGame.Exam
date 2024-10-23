using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ESCMenu : MonoBehaviour
{
    public GameObject EscMenu;
    private bool Aktive;
    private PlayerInput  pInput;
    private PlayerInput pInputEscape;

    PlayerStats PlayerStat;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
        pInputEscape = GetComponent<PlayerInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pInputEscape.actions["Escape"].WasPressedThisFrame() && !Aktive && PlayerStat.Alive)
        {
            EscMenu.SetActive(true);
            Aktive = true;
            pInput.DeactivateInput(); 
            Time.timeScale = 0;


        }
        else if (pInputEscape.actions["Escape"].WasPressedThisFrame() && Aktive && PlayerStat.Alive)
        {
            EscMenu.SetActive(false);
            Aktive = false;
            pInput.ActivateInput();
            Time.timeScale = 1;


        }
        
    }
    public void Resume()
    {
        EscMenu.SetActive(false);
        Aktive = false;
        pInput.ActivateInput();
        Time.timeScale = 1;
    }
}
