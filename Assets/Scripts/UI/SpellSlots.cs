using System;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SpellSlots : MonoBehaviour
{
    SpellInventory spellInventory;
    public int SlotNumber;
    private Texture ri;
    private RawImage RI;

    public GameObject emptySlot;
    public GameObject filledSlot;
    public GameObject spellList;

    public enum SlotType
    {
        none,
        BasicAttack,
        SpellSlot
    }

    public SlotType slotType;
    public bool clickOnEnable;


    void OnEnable()
    {   
        spellInventory = GameObject.Find("GameManager").GetComponentInChildren<SpellInventory>();
        RI = GetComponent<RawImage>();
        emptySlot.SetActive(false);
        filledSlot.SetActive(false);

    }

    void Update()
    {
    
        if (SlotType.SpellSlot == slotType && spellInventory.spellsEuipe[SlotNumber-1] != null)
        {
            ri = spellInventory.spellsEuipe[SlotNumber-1].transform.GetComponent<GeneraldSpellModule>().itemUiImage;
            this.gameObject.GetComponent<RawImage>().texture = ri;
            this.gameObject.GetComponent<RawImage>().color = Color.white;

        }
        else if (SlotType.BasicAttack == slotType && spellInventory.BasicAttack != null)
        {
            ri = spellInventory.BasicAttack.transform.GetComponent<GeneraldSpellModule>().itemUiImage;
            this.gameObject.GetComponent<RawImage>().texture = ri;
            this.gameObject.GetComponent<RawImage>().color = Color.white;
        }
        else 
        {
             this.gameObject.GetComponent<RawImage>().texture = null;
              this.gameObject.GetComponent<RawImage>().color = Color.clear;
        }

    }

    public void OpenSpellList(int spellSlot)
    {
        ClickOn();
        SpellSlotList.EuipeSlot = spellSlot;
        spellList.SetActive(true);

    }

    public void UnequipSpell()
    {
        if (SlotType.SpellSlot == slotType && spellInventory.spellsEuipe[SlotNumber-1] != null)
        {
            ClickOn();
            spellInventory.Spells.Add(spellInventory.spellsEuipe[SlotNumber-1]);
            spellInventory.spellsEuipe[SlotNumber-1] = null;

        }
        else if (SlotType.BasicAttack == slotType && spellInventory.BasicAttack != null)
        {
            ClickOn();
            spellInventory.BasicAttackList.Add(spellInventory.BasicAttack);
            spellInventory.BasicAttack = null;
        }
    }

    public void ClickOn()
    {   
        if (!clickOnEnable)
        {

            clickOnEnable = true;
            if (SlotType.SpellSlot == slotType && spellInventory.spellsEuipe[SlotNumber-1] != null)
            {
                emptySlot.SetActive(false);
                filledSlot.SetActive(true);

            }
            else if (SlotType.SpellSlot == slotType && spellInventory.spellsEuipe[SlotNumber-1] == null)
            {
                emptySlot.SetActive(true);
                filledSlot.SetActive(false);
            }
            else if (SlotType.BasicAttack == slotType && spellInventory.BasicAttack != null)
            {
                emptySlot.SetActive(false);
                filledSlot.SetActive(true);
            }
            else if (SlotType.BasicAttack == slotType && spellInventory.BasicAttack == null)
            {
                emptySlot.SetActive(true);
                filledSlot.SetActive(false);
            }
        }
        else if (clickOnEnable)
        {
            clickOnEnable = false;
            emptySlot.SetActive(false);
            filledSlot.SetActive(false);

        }

        

    }
    


}
