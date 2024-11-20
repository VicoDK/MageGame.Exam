using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using System.Linq;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    //to make sure there is only one inventory
    public static Inventory Instance = null;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

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
        inventory = Instance;

    
    }

    void Update()
    {
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
            if (inventory.items[i].Amount == 0)
            {
                inventory.items[i].Items = null;
            }

        }
    }

public static void Getitem(GameObject item)
{
    Transform PlayerPOS = GameObject.Find("PlayerBody").GetComponent<Transform>();
    Movment PlayerMovement = GameObject.Find("PlayerBody").GetComponent<Movment>();
    Inventory inventory = Instance;
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


/*public static void Getitem3(GameObject item)
    {
        //when inv is almost full it fails 
        //oijfsngh;
        Inventory inventory = Instance;
        int steps = 1;
        int[] counter = new int[inventory.items.Length];
        int index = 0;
        bool itemAdded = false;


        for(int i = 0; i < 11; i++)
        {

            switch (steps)
            {
                case 1: // checks if the player has the item
                Debug.Log(1);
                if (inventory.items[i].Items == item) // same item and under stack count
                {

                    counter[index] = i;
                    index++;
                    break;
                }


                if (i == inventory.items.Length-1)
                {
                    steps = 2;
                }

                break;
                case 2: //gives player the item or sent to next step

                for (int j = 0; j <= counter.Length-1; j++)
                {
                    if (inventory.items[counter[j]].Amount < item.GetComponent<ItemPickUp>().MaxStack && inventory.items[counter[j]].Items == item && !itemAdded)
                    {
                        inventory.items[counter[j]].Amount++;
                        i = -10;
                        itemAdded = true;
                        break;

                    }
                    else if (inventory.items[counter[j]].Items == item)
                    {
                        index--;
                    }

                    if (index == 0) 
                    {

                        steps = 3;
                        i = -1;
                        break;
                    }
                
                }
                break;
                case 3: // adds item to new spot

                    if (inventory.items[i].Items == null && !itemAdded)
                    {
                        
                        inventory.items[i].Items = item;
                        inventory.items[i].Amount = 1;
                        itemAdded = false;
                        i = -10;
                        break;
                    }

                break;

            }

        }

    }*/
    
    public static void Getitem2(GameObject item)
    {
        // Access the instance of Inventory
        Inventory inventory = Instance;
        string Process = "Start";
        //bool done = false;
        
        /*while (!done)
        {*/
        for(int j = 0; j < 5; j++)
        {

            switch (Process)
            {
                case "Start":
                    //check if the player has the item
                    for (int i = 0; i < inventory.items.Length; i++)
                    {

                        
                        // Check if the Items property of the Item instance matches the GameObject
                        if (inventory.items[i].Items == item)
                        {
                            if (inventory.items[i].Amount < 16/*item.GetComponent<ItemPickUp>().MaxStack*/)
                            {

                                Process = "Contains";   
                            }
                            else if (inventory.items[i].Amount <= 16/*item.GetComponent<ItemPickUp>().MaxStack*/)
                            {

                                Process = "FindSpot";
                                break;
                            }
                            
                        }

                    }
                    if (Process != "Contains" )
                    {
                        Process = "FindSpot";
                    }

                break;
                case "Contains":
                    for (int i = 0; i < inventory.items.Length; i++)
                    {


                        if (inventory.items[i].Items.GetComponent<ItemPickUp>().itemName == item.GetComponent<ItemPickUp>().itemName && 
                            item.GetComponent<ItemPickUp>().Stackable)
                        {
                            if (inventory.items[i].Amount < item.GetComponent<ItemPickUp>().MaxStack)
                            {
                                inventory.items[i].Amount++;
                                j = 10;
                            }
                            else
                            {

                                Process = "FindSpot2";
                            }
                            
                            break;
                        }


                    }
                break;
                case "FindSpot":
                Debug.Log("test");
                    for (int i = 0; i < inventory.items.Length; i++)
                    {
                        if (inventory.items[i].Items == null)
                        {
                            inventory.items[i].Items = item;
                            inventory.items[i].Amount = 1;
                            j = 10;
                            
                            break;
                        }
                    }

                break;
                case "FindSpot2":
                //find spot if there is 1 or more filled spots with the same item
                
                break;
                default:

                Debug.Log("dont know what to do!");
                //done = true;
                
                break;

            }
        }
    }
}

            /*//check if the player has the item
            for (int i = 0; i < inventory.items.Length; i++)
            {
                // Check if the Items property of the Item instance matches the GameObject
                if (inventory.items[i].Items == item)
                {
                    contains = true;
                    break; // The array contains the GameObject
                }
                else if (i == inventory.items.Length )
                {
                    contains = false;
                    break;
                }
            }

            for (int i = 0; i < inventory.items.Length; i++)
            {

                if (inventory.items[i].Items == null && !contains)
                {
                    inventory.items[i].Items = item;
                    inventory.items[i].Amount = 1;
                    break;
                }
                else if (inventory.items[i].Items.GetComponent<ItemPickUp>().itemName == item.GetComponent<ItemPickUp>().itemName && item.GetComponent<ItemPickUp>().Stackable && inventory.items[i].Amount < item.GetComponent<ItemPickUp>().MaxStack)
                {
                    inventory.items[i].Amount++;
                    break;
                }
                
            }*/