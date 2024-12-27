using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ShopMenu : MonoBehaviour
{

    public GameObject itself; // it self

    [Header("Player")]
    public GameObject PlayerUI; //player ui
    public TMP_Text Coins; //coin text



    private PlayerStats PlayerStat;
    public Inventory inventory;



    void Update()
    {
        Coins.text = (inventory.coin+ ""); //track players coins and displayes it

        if (Controls.PInput.actions["Escape"].WasPressedThisFrame()|| Controls.PInput.actions["Interact"].WasPressedThisFrame()) // if ESC pressed
        {
            itself.SetActive(false); //disables the shop
        }


    }

    private void OnEnable() //on enable 
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        PlayerUI = GameObject.Find("PlayerCanvas");
        PlayerUI.SetActive(false); //diable player ui
        PlayerStat.Shopping = true; //stops the player from moving
        Time.timeScale = 0;


        
    }

    private void OnDisable() // on diable 
    {
        PlayerUI.SetActive(true); // turn player ui on
        PlayerStat.Shopping = false; // enables the player movement
        Time.timeScale = 1;
  
    }

    
    

    public void ExitShop() //exit button
    {
        itself.SetActive(false); //disables the shop
    }
    
}
