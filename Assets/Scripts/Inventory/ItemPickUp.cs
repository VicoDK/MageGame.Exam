using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    //Inventory inventory;
    private bool pickup = false;
    public string itemName;

    public bool Stackable;
    public Texture itemUiImage;
    public int MaxStack;
    public GameObject itemPrefab;
    private bool delayPickUp = false;
    public float delayPickUpTime;
    private GameObject itemManager;
    public string ItemNameInResources;

    void Start()
    {   
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
        //if player
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!pickup && delayPickUp)
            {
                pickup = true;
                gameObject.SetActive(false);   
                Inventory.Getitem(itemPrefab);
            }


            // Get the Inventory component from the player object
            /*inventory = collision.transform.parent.GetComponentInChildren<Inventory>();
            if (inventory != null && !pickup)
            {   // remake for list (mylist.contains(thing))

                for (int i = 0; i < inventory.items.Length; i++)
                {
                    if (inventory.items[i].Items == null)
                    {
                        pickup = true;
                        inventory.items[i].Items =this.transform.gameObject;
                        inventory.items[i].Amount = 1;
                        gameObject.SetActive(false);
                        break;
                    }
                    else if (inventory.items[i].Items.GetComponent<ItemPickUp>().itemName == itemName && Stackable)
                    {

                        pickup = true;
                        inventory.items[i].Amount++;
                        gameObject.SetActive(false);
                        break;
                    }
                    
                }
                
            }*/
        }
    }
}