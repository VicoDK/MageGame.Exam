using System;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{
    Inventory inventory;
    ToolInventory toolInventory;
    public int SlotNumber;
    private Texture ri;
    TMP_Text count;
    Transform PlayerPOS;
    Movment PlayerMovement;
    public int dropSpeed;
    private bool clickOnEnable;
    
    public GameObject useUI;
    public GameObject normalUI;
    public GameObject equipUI;
    public GameObject unequip;
    public GameObject empty;

    public enum SlotType
    {
        ItemSlot,
        CloakSlot,
        StaffSlot,
        ToolSlot
    }

    public SlotType slotType;


    void Start()
    {   
        inventory = GameObject.Find("GameManager").GetComponentInChildren<Inventory>();
        toolInventory = GameObject.Find("GameManager").GetComponentInChildren<ToolInventory>();
        count = GetComponentInChildren<TMP_Text>();
        PlayerPOS = GameObject.Find("PlayerBody").GetComponent<Transform>();
        PlayerMovement = GameObject.Find("PlayerBody").GetComponent<Movment>();
    }

    void Update()
    {

        if (useUI == null)
        {
            useUI = empty;
        }

        if (normalUI == null)
        {
            normalUI = empty;  
        }

        if (equipUI == null)
        {
            equipUI = empty;   
        }

        if (unequip == null)
        {
            unequip = empty;
        }



        if (slotType == SlotType.ItemSlot)
        {

            //display image   
            if (inventory.items[SlotNumber-1].Items != null)
            {
                ri = inventory.items[SlotNumber-1].Items.transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().color = Color.white;
                this.gameObject.GetComponent<RawImage>().texture = ri;

                
            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().color = Color.clear;
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

            
        }
        else if (slotType == SlotType.CloakSlot)
        {
            //display image   
            if (toolInventory.cloakSlot != null)
            {
                ri = toolInventory.cloakSlot.transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().color = Color.white;
                this.gameObject.GetComponent<RawImage>().texture = ri;

                
            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().color = Color.clear;
                this.gameObject.GetComponent<RawImage>().texture = null;


            }
        }
        else if (slotType == SlotType.StaffSlot)
        {
            //display image   
            if (toolInventory.staffSlot != null)
            {
                ri = toolInventory.staffSlot.transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().color = Color.white;
                this.gameObject.GetComponent<RawImage>().texture = ri;

            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().color = Color.clear;
                this.gameObject.GetComponent<RawImage>().texture = null;

            }

        }
        else if (slotType == SlotType.ToolSlot)
        {


            if (toolInventory.Tools[SlotNumber-1] != null)
            {
                ri = toolInventory.Tools[SlotNumber-1].transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().color = Color.white;
                this.gameObject.GetComponent<RawImage>().texture = ri;

                
            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().color = Color.clear;
                this.gameObject.GetComponent<RawImage>().texture = null;
            }
        }



    }

    public void OnDisable()
    {
        clickOnEnable = false;
        useUI.SetActive(false); 
        normalUI.SetActive(false); 
        equipUI.SetActive(false); 
        
    }

    public void Drop()
    {
        if (slotType == SlotType.ItemSlot)
        {
            ClickOn();
            GameObject item = Instantiate(inventory.items[SlotNumber-1].Items, PlayerPOS.position, Quaternion.identity);
            item.GetComponent<Rigidbody2D>().AddForce(new Vector2(PlayerMovement.LookDIR, 0) * dropSpeed, ForceMode2D.Impulse);
            inventory.items[SlotNumber-1].Amount--;
        }
        else if (slotType == SlotType.ToolSlot) 
        {
            ClickOn();
            GameObject item = Instantiate(toolInventory.Tools[SlotNumber-1], PlayerPOS.position, Quaternion.identity);
            item.GetComponent<Rigidbody2D>().AddForce(new Vector2(PlayerMovement.LookDIR, 0) * dropSpeed, ForceMode2D.Impulse);
            toolInventory.Tools[SlotNumber-1] = null;
        } 
    }




    public void UseItemInSlot()
    {

        inventory.items[SlotNumber-1].Items.GetComponent<itemUse>().UseItem(SlotNumber);
    }

    public void Equip()
    {
        if (toolInventory.Tools[SlotNumber-1].GetComponent<itemUse>().itemType == itemUse.whatItem.Staff)
        {
            ClickOn();
            if (toolInventory.staffSlot == null)
            {
                toolInventory.staffSlot = toolInventory.Tools[SlotNumber-1];
                toolInventory.Tools[SlotNumber-1] = null;
            }
            else 
            {
                GameObject itemHold = toolInventory.staffSlot;
                toolInventory.staffSlot = toolInventory.Tools[SlotNumber-1];
                toolInventory.Tools[SlotNumber-1] = itemHold;
            }
        }
        else if (toolInventory.Tools[SlotNumber-1].GetComponent<itemUse>().itemType == itemUse.whatItem.Cloak)
        {
            ClickOn();
            if (toolInventory.cloakSlot == null)
            {
                toolInventory.cloakSlot = toolInventory.Tools[SlotNumber-1];
                toolInventory.Tools[SlotNumber-1] = null;
            }
            else 
            {
                GameObject itemHold = toolInventory.cloakSlot;
                toolInventory.cloakSlot = toolInventory.Tools[SlotNumber-1];
                toolInventory.Tools[SlotNumber-1] = itemHold;
            }

        }
        else 
        {
            Debug.Log("dont work");
        }
    }

    public void UnequipStaff()
    {
        ClickOn();
        ToolInventory.GetTool(toolInventory.staffSlot);
        toolInventory.staffSlot = null;


    }
    public void UnequipCloak()
    {
        ClickOn();
        ToolInventory.GetTool(toolInventory.cloakSlot);
        toolInventory.cloakSlot = null;


    }

    public void ClickOn()
    {
        if (clickOnEnable)
        {
            clickOnEnable = false;
            if (useUI != null)
            {
                useUI.SetActive(false); 
            }
            
            if (normalUI != null)
            {
                normalUI.SetActive(false); 
            }

            if (equipUI != null)
            {
                equipUI.SetActive(false); 
            }
        }
        else if (!clickOnEnable && slotType == SlotType.ItemSlot)
        { 
            clickOnEnable = true;
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
                equipUI.SetActive(false);           
            }

        }
        else if (!clickOnEnable && slotType == SlotType.ToolSlot)
        {
            clickOnEnable = true;
            if (toolInventory.Tools[SlotNumber-1].GetComponent<itemUse>().equip)
            {
                useUI.SetActive(false);
                normalUI.SetActive(false);
                equipUI.SetActive(true);
            }

        }
        else if (!clickOnEnable && slotType == SlotType.CloakSlot ) 
        {
            clickOnEnable = true;
            if (toolInventory.cloakSlot.GetComponent<itemUse>().equip)
            {
                useUI.SetActive(false);
                normalUI.SetActive(false);
                equipUI.SetActive(true);
            }

        }
        else if (!clickOnEnable |slotType == SlotType.StaffSlot ) 
        {
            clickOnEnable = true;
            if (toolInventory.staffSlot.GetComponent<itemUse>().equip)
            {
                useUI.SetActive(false);
                normalUI.SetActive(false);
                equipUI.SetActive(true);
            }

        }



    }
}