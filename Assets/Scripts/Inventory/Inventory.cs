using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using System.Linq;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    [System.Serializable] public class Item
    {
        public GameObject Items;
        public int Amount;
    }

    public Item[] items;
    //public List<Item> items;

    public GameObject staffSlot;
    public GameObject cloakSlot;
    
    public int coin;

    public TMP_Text CoinAmountDisplay;
    Inventory inventory;



    void Start()
    {
        CoinAmountDisplay = GameObject.Find("PlayerCoinAmount").GetComponent<TMP_Text>();
    }


    void Update()
    {
        if (CoinAmountDisplay == null)
        {
            CoinAmountDisplay = GameObject.Find("PlayerCoinAmount").GetComponent<TMP_Text>();
        }

        if (staffSlot != null)
        {
            if (staffSlot.gameObject.GetComponent<itemUse>().itemType != itemUse.whatItem.Staff)
            {
                Getitem(staffSlot);
                staffSlot = null;
            }

        }

        if (cloakSlot != null)
        {
            if (cloakSlot.gameObject.GetComponent<itemUse>().itemType != itemUse.whatItem.Cloak)
            {
                Getitem(cloakSlot);
                cloakSlot = null;
            }
        }


        //Array.Resize<Item>(ref items, 1);
        CoinAmountDisplay.text = (coin + " ");

        for(int i = 0; i < items.Length; i++)
        {
            if (items[i].Amount == 0)
            {
                items[i].Items = null;
            }

        }
    }

public static void Getitem(GameObject item)
{
    Transform PlayerPOS = GameObject.Find("PlayerBody").GetComponent<Transform>();
    Movment PlayerMovement = GameObject.Find("PlayerBody").GetComponent<Movment>();
    Inventory inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();;
    bool itemAdded = false;
    int step = 1;


    while (!itemAdded)
    {

        switch (step) 
        {

            case 1:
            for (int i = 0; i < inventory.items.Length+1; i++)
            {
                if (i < inventory.items.Length)
                {
                    if (inventory.items[i].Items == item && item.GetComponent<ItemPickUp>().MaxStack != inventory.items[i].Amount)
                    {

                        inventory.items[i].Amount++; 
                        itemAdded = true;
                        break;
                    }
                }
                else 
                {
                    step = 2;
                    break;
                }

            }

            break;
            case 2:
            for (int i = 0; i < inventory.items.Length+1; i++)
            {
                if (i < inventory.items.Length)
                {
                    if (inventory.items[i].Items == null)
                    {
                        inventory.items[i].Items = item;
                        inventory.items[i].Amount = 1;
                        itemAdded = true;
                        break;
                    }
                    }
                else 
                {
                    GameObject itemDrop = Instantiate(item, PlayerPOS.position, Quaternion.identity);
                    itemDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(PlayerMovement.LookDIR, 0) * 1, ForceMode2D.Impulse);
                    itemAdded = true;
                    break;
                }
            }  
            break;
        }
    }




}


}