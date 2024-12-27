using System;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
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
    private bool clickOnEnable;
    
    public GameObject useUI;
    public GameObject normalUI;
    public GameObject equipUI;
    public GameObject unequip;

    public enum SlotType
    {
        ItemSlot,
        CloakSlot,
        StaffSlot
    }

    public SlotType slotType;


    void Start()
    {   
        inventory = GameObject.Find("GameManager").GetComponentInChildren<Inventory>();
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
            if (inventory.cloakSlot != null)
            {
                ri = inventory.cloakSlot.transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().texture = ri;
                unequip.SetActive(true);
                
            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().texture = null;
                unequip.SetActive(false);

            }
        }
        else if (slotType == SlotType.StaffSlot)
        {
            //display image   
            if (inventory.staffSlot != null)
            {
                ri = inventory.staffSlot.transform.GetComponent<ItemPickUp>().itemUiImage;

                this.gameObject.GetComponent<RawImage>().texture = ri;
                unequip.SetActive(true);
            }
            else 
            {
                this.gameObject.GetComponent<RawImage>().texture = null;
                unequip.SetActive(false);

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
        GameObject item = Instantiate(inventory.items[SlotNumber-1].Items, PlayerPOS.position, Quaternion.identity);
        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(PlayerMovement.LookDIR, 0) * dropSpeed, ForceMode2D.Impulse);
        inventory.items[SlotNumber-1].Amount--;
        
    }

    public void UseItemInSlot()
    {

        inventory.items[SlotNumber-1].Items.GetComponent<itemUse>().UseItem(SlotNumber);
    }

    public void Equip()
    {
        if (inventory.items[SlotNumber-1].Items.GetComponent<itemUse>().itemType == itemUse.whatItem.Staff)
        {
            if (inventory.staffSlot == null)
            {
                inventory.staffSlot = inventory.items[SlotNumber-1].Items;
                inventory.items[SlotNumber-1].Items = null;
            }
            else 
            {
                GameObject itemHold = inventory.staffSlot;
                inventory.staffSlot = inventory.items[SlotNumber-1].Items;
                inventory.items[SlotNumber-1].Items = itemHold;
            }
        }
        else if (inventory.items[SlotNumber-1].Items.GetComponent<itemUse>().itemType == itemUse.whatItem.Cloak)
        {
            if (inventory.cloakSlot == null)
            {
                inventory.cloakSlot = inventory.items[SlotNumber-1].Items;
                inventory.items[SlotNumber-1].Items = null;
            }
            else 
            {
                GameObject itemHold = inventory.cloakSlot;
                inventory.cloakSlot = inventory.items[SlotNumber-1].Items;
                inventory.items[SlotNumber-1].Items = itemHold;
            }

        }
        else 
        {
            Debug.Log("dont work");
        }
    }

    public void UnequipStaff()
    {
        Inventory.Getitem(inventory.staffSlot);
        inventory.staffSlot = null;


    }
    public void UnequipCloak()
    {
        Inventory.Getitem(inventory.cloakSlot);
        inventory.cloakSlot = null;


    }

    public void ClickOn()
    {
        if (clickOnEnable)
        {
            clickOnEnable = false;
            useUI.SetActive(false);
            normalUI.SetActive(false); 
            equipUI.SetActive(false);
        }
        else if (!clickOnEnable)
        { 
            clickOnEnable = true;
            if (inventory.items[SlotNumber-1].Items != null)
            {
                if (inventory.items[SlotNumber-1].Items.GetComponent<itemUse>().canUse)
                {
                    useUI.SetActive(true);
                    normalUI.SetActive(false);
                    equipUI.SetActive(false);
                }
                else if (inventory.items[SlotNumber-1].Items.GetComponent<itemUse>().equip)
                {
                    useUI.SetActive(false);
                    normalUI.SetActive(false);
                    equipUI.SetActive(true);
                }
                else
                {
                    useUI.SetActive(false);
                    normalUI.SetActive(true);
                    equipUI.SetActive(false);

                }

            }
            else 
            {
                useUI.SetActive(false);
                normalUI.SetActive(false); 
                equipUI.SetActive(false);           
            }

        }
    }



}
