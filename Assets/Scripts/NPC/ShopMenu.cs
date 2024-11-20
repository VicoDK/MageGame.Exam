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


    private PlayerStats PlayerStat;
    public PlayerInput  pInput;
    public Inventory inventory;
    public GameObject sellItem1;
    

    void Start()
    {
        Price1Text.text = ("Price " + Price1); //text for buttons
        Price2Text.text = ("Price " + Price2);
        Price3Text.text = ("Price " + Price3);
        Price4Text.text = ("Price " + Price4);

        
    }

    void Update()
    {
        Coins.text = (inventory.coin+ ""); //track players coins and displayes it

        if (pInput.actions["Escape"].WasPressedThisFrame()|| pInput.actions["Interact"].WasPressedThisFrame()) // if ESC pressed
        {
            itself.SetActive(false); //disables the shop
        }
    }

    private void OnEnable() //on enable 
    {
        pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        PlayerUI.SetActive(false); //diable player ui
        PlayerStat.Shopping = true; //stops the player from moving
        Time.timeScale = 0;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();


        
    }

    private void OnDisable() // on diable 
    {
        PlayerUI.SetActive(true); // turn player ui on
        PlayerStat.Shopping = false; // enables the player movement
        Time.timeScale = 1;
  
    }

    public void buy1() //button 1
    {
        if (inventory.coin >= Price1) //checks if player has enough coin   
        {
            inventory.coin -= Price1; //takes the players coins
            Script.ContractsCall(1); // call functioin in script
        }

    }
    
    public void buy2()
    {
        if (inventory.coin >= Price2)
        {
            inventory.coin -= Price2;
            Inventory.Getitem(sellItem1);
            

        }
        
    }

    public void buy3()
    {
        if (inventory.coin >= Price3)
        {
            inventory.coin -= Price3;
        }
  
    }

    public void buy4()
    {
        if (inventory.coin >= Price4)
        {
            inventory.coin -= Price4;
        }
    }

    public void ExitShop() //exit button
    {
        itself.SetActive(false); //disables the shop
    }

    

    /*void GiveItem(GameObject item)
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i].Items == null)
            {
                inventory.items[i].Items = item;
                inventory.items[i].Amount = 1;
                break;
            }
            else if (inventory.items[i].Items.GetComponent<ItemPickUp>().itemName == item.GetComponent<ItemPickUp>().itemName && item.GetComponent<ItemPickUp>().Stackable)
            {
                inventory.items[i].Amount++;
                break;
            }
                    
        }
    }*/
    
}
