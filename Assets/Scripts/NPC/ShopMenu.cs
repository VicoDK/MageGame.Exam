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


    public PlayerStats PlayerStat;

    void Start()
    {
        Price1Text.text = ("Price " + Price1); //text for buttons
        Price2Text.text = ("Price " + Price2);
        Price3Text.text = ("Price " + Price3);
        Price4Text.text = ("Price " + Price4);
       



        
    }

    void Update()
    {
        Coins.text = (PlayerStat.Coin + " Coins"); //track players coins and displayes it

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I)) // if ESC pressed
        {
            itself.SetActive(false); //disables the shop
        }
    }

    private void OnEnable() //on enable 
    {
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        PlayerUI.SetActive(false); //diable player ui
        PlayerStat.Shopping = true; //stops the player from moving

        
    }

    private void OnDisable() // on diable 
    {
        PlayerUI.SetActive(true); // turn player ui on
        PlayerStat.Shopping = false; // enables the player movement
  
    }

    public void buy1() //button 1
    {
        if (PlayerStat.Coin >= Price1) //checks if player has enough coin   
        {
            PlayerStat.Coin -= Price1; //takes the players coins
            Script.ContractsCall(1); // call functioin in script
        }

    }
    
    public void buy2()
    {
        if (PlayerStat.Coin >= Price2)
        {
            PlayerStat.Coin -= Price2;
        }
        
    }

    public void buy3()
    {
        if (PlayerStat.Coin >= Price3)
        {
            PlayerStat.Coin -= Price3;
        }
  
    }

    public void buy4()
    {
        if (PlayerStat.Coin >= Price4)
        {
            PlayerStat.Coin -= Price4;
        }
    }

    public void ExitShop() //exit button
    {
        itself.SetActive(false); //disables the shop
    }
    
}
