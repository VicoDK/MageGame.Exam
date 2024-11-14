using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{
    Inventory inventory;
    public int SlotNumber;
    private Texture ri;
    TMP_Text count;
    Transform PlayerPOS;
    Movment PlayerMovement;
    public int dropSpeed;
    
    public GameObject useUI;
    public GameObject normalUI;

    public enum SlotType
    {
        ItemSlot,
        CloakSlot,
        StaffSlot
    }

    public SlotType slotType;


    void Start()
    {   
        inventory = GameObject.Find("CanvasG").GetComponent<Inventory>();
        count = GetComponentInChildren<TMP_Text>();
        PlayerPOS = GameObject.Find("PlayerBody").GetComponent<Transform>();
        PlayerMovement = GameObject.Find("PlayerBody").GetComponent<Movment>();
    }

    void Update()
    {
        if (slotType == SlotType.ItemSlot)
        {

            //display image   
            if (inventory.items[SlotNumber-1].Items != null)
            {
                ri = inventory.items[SlotNumber-1].Items.transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().texture = ri;
                
            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().texture = null;
            }

            //display amount
            if (inventory.items[SlotNumber-1].Amount > 1)
            {
                count.text = (inventory.items[SlotNumber-1].Amount + "");
            }
            else
            {
                count.text = ("");
            }

            //check if usecase
            if (inventory.items[SlotNumber-1].Items != null)
            {
                if (inventory.items[SlotNumber-1].Items.GetComponent<itemUse>().canUse)
                {
                    useUI.SetActive(true);
                    normalUI.SetActive(false);
                }
                else 
                {
                    useUI.SetActive(false);
                    normalUI.SetActive(true);

                }

            }
            else 
            {
                useUI.SetActive(false);
                normalUI.SetActive(false);            
            }
        }
        else if (slotType == SlotType.CloakSlot)
        {
            //display image   
            if (inventory.cloakSlot != null)
            {
                ri = inventory.cloakSlot.transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().texture = ri;
                
            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().texture = null;
            }
        }
        else if (slotType == SlotType.StaffSlot)
        {
            //display image   
            if (inventory.staffSlot != null)
            {
                ri = inventory.staffSlot.transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().texture = ri;
                
            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().texture = null;
            }

        }



    }

    public void Drop()
    {
        GameObject item = Instantiate(inventory.items[SlotNumber-1].Items, PlayerPOS.position, Quaternion.identity);
        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(PlayerMovement.LookDIR, 0) * dropSpeed, ForceMode2D.Impulse);
        inventory.items[SlotNumber-1].Amount--;
        
    }

    public void UseItemInSlot()
    {

        inventory.items[SlotNumber-1].Items.GetComponent<itemUse>().UseItem(SlotNumber);
    }



}
