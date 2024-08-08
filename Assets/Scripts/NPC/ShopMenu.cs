using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{

    public GameObject itself; // it self
    [Header("Shop Text and Prise")]
    public int Price1; //price variable
    public TMP_Text Price1Text; // the text
    public int Price2;
    public TMP_Text Price2Text;
    public int Price3;
    public TMP_Text Price3Text;
    public int Price4;
    public TMP_Text Price4Text;

    [Header("Player")]
    public GameObject PlayerUI; //player ui
    public TMP_Text Coins; //coin text


    public ContractsTracker Script; //holds script

    void Start()
    {
        Price1Text.text = ("Price " + Price1); //text for buttons
        Price2Text.text = ("Price " + Price2);
        Price3Text.text = ("Price " + Price3);
        Price4Text.text = ("Price " + Price4);



        
    }

    void Update()
    {
        Coins.text = (PlayerStats.CoinAmount + " Coins"); //track players coins and displayes it

        if (Input.GetKeyDown(KeyCode.Escape)) // if ESC pressed
        {
            itself.SetActive(false); //disables the shop
        }
    }

    private void OnEnable() //on enable 
    {
        
        PlayerUI.SetActive(false); //diable player ui
        PlayerStats.Shopping = true; //stops the player from moving
        
    }

    private void OnDisable() // on diable 
    {
        PlayerUI.SetActive(true); // turn player ui on
        PlayerStats.Shopping = false; // enables the player movement
    }

    public void buy1() //button 1
    {
        if (PlayerStats.Coin >= Price1) //checks if player has enough coin   
        {
            PlayerStats.Coin -= Price1; //takes the players coins
            Script.ContractsCall(1); // call functioin in script
        }

    }
    
    public void buy2()
    {
        if (PlayerStats.Coin >= Price2)
        {
            PlayerStats.Coin -= Price2;
        }
        
    }

    public void buy3()
    {
        if (PlayerStats.Coin >= Price3)
        {
            PlayerStats.Coin -= Price3;
        }
  
    }

    public void buy4()
    {
        if (PlayerStats.Coin >= Price4)
        {
            PlayerStats.Coin -= Price4;
        }
    }

    public void ExitShop() //exit button
    {
        itself.SetActive(false); //disables the shop
    }
    
}
