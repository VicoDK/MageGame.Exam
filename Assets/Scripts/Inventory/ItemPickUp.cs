using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    //Inventory inventory;
    private bool pickup = false;
    private bool runWhile = true;
    public string itemName;

    public bool Stackable;
    public Texture itemUiImage;
    public int MaxStack;
    public GameObject itemPrefab;
    private bool delayPickUp = false;
    public float delayPickUpTime;
    private GameObject itemManager;
    public string ItemNameInResources;
    private int step = 1;
    Inventory inventory;
    ToolInventory toolInventory;

    public bool tool;

    void Start()
    {   
        inventory = GameObject.Find("GameManager").GetComponentInChildren<Inventory>();
        toolInventory = GameObject.Find("GameManager").GetComponentInChildren<ToolInventory>();
        itemManager = GameObject.Find("ItemManager");
        this.transform.parent = itemManager.transform;
        itemPrefab = Resources.Load<GameObject>(ItemNameInResources);
        Invoke("DelayPickUpFunc", delayPickUpTime);
    }

    void DelayPickUpFunc()
    {
        delayPickUp = true;
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!tool)  
        {

            //if player
            if (collision.gameObject.CompareTag("Player") && delayPickUp && !pickup)
            {
                runWhile = true;
                step = 1;

                while (runWhile)
                {
                    switch (step) 
                    {
                        case 1:
                        for (int i = 0; i < inventory.items.Length+1; i++)
                        {
                            if (i < inventory.items.Length)
                            {

                                if (inventory.items[i].Items == itemPrefab && itemPrefab.GetComponent<ItemPickUp>().MaxStack != inventory.items[i].Amount)
                                {

                                    pickup = true;
                                    runWhile = false;
                                    gameObject.SetActive(false);   
                                    Inventory.Getitem(itemPrefab);
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
                                        pickup = true;
                                        runWhile = false;
                                        gameObject.SetActive(false);   
                                        Inventory.Getitem(itemPrefab);
                                        break;
                                    }
                                        
                                }

                            }
                            runWhile = false;
                        break;
                    }
                }

            
            }

        }
        else if (tool)
        {   

            if (collision.gameObject.CompareTag("Player") && delayPickUp && !pickup)
            {



   
                for (int i = 0; i < toolInventory.Tools.Length+1; i++)
                {
                    if (i < toolInventory.Tools.Length)
                    {
                        if (toolInventory.Tools[i] == null && !pickup )
                        {

                            pickup = true;
                            gameObject.SetActive(false); 
                            ToolInventory.GetTool(itemPrefab);
                        }

                    }

                } 
                    

            }
        }
    }
    
}
