using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shop : MonoBehaviour
{
    //generald shop stuff
    [Header("Shop")]
    public GameObject ShopMenu;
    public GameObject ShopPromt;
    private bool InRange;

    PlayerStats PlayerStats;
    private PlayerInput  pInput;

    void Start()
    {
        PlayerStats = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
    }


    void OnTriggerEnter2D(Collider2D collision) //Something enters 
    {   
        if (collision.gameObject.CompareTag("Player")) // if player
        {   

            ShopPromt.SetActive(true); //activates shop promt
            InRange = true; //player ind range true


        }
        

    }

    void OnTriggerExit2D(Collider2D collision) //somthing exits
    {
        if (collision.gameObject.CompareTag("Player")) // if player
        {
            ShopPromt.SetActive(false); //deactivates shop promt
            InRange = false; //player ind range false

        }
    }

    void Update()
    {
        if (pInput.actions["Interact"].WasPressedThisFrame() && InRange && !PlayerStats.Shopping) //if pressed Interact and in rang
        {   
            ShopMenu.SetActive(true); // activate shop

        }
    }
}
