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


    void OnEnable()
    {   
        spellInventory = GameObject.Find("GameManager").GetComponentInChildren<SpellInventory>();
        RI = GetComponent<RawImage>();

    }

    void Update()
    {
    
        if (SlotType.SpellSlot == slotType && spellInventory.spellsEuipe[SlotNumber-1] != null)
        {
            ri = spellInventory.spellsEuipe[SlotNumber-1].transform.GetComponent<GeneraldSpellModule>().itemUiImage;
            this.gameObject.GetComponent<RawImage>().texture = ri;
            RI.color =  new Color(255, 255, 255);

        }
        else if (SlotType.BasicAttack == slotType && spellInventory.BasicAttack != null)
        {
            ri = spellInventory.BasicAttack.transform.GetComponent<GeneraldSpellModule>().itemUiImage;
            this.gameObject.GetComponent<RawImage>().texture = ri;
            RI.color =  new Color(255, 255, 255);
        }
        else 
        {
             this.gameObject.GetComponent<RawImage>().texture = null;
             RI.color =  Color.green;
        }

    }

    public void OpenSpellList(int spellSlot)
    {
        SpellSlotList.EuipeSlot = spellSlot;
        spellList.SetActive(true);

    }

    public void UnequipSpell()
    {
        if (SlotType.SpellSlot == slotType && spellInventory.spellsEuipe[SlotNumber-1] != null)
        {
            spellInventory.Spells.Add(spellInventory.spellsEuipe[SlotNumber-1]);
            spellInventory.spellsEuipe[SlotNumber-1] = null;

        }
        else if (SlotType.BasicAttack == slotType && spellInventory.BasicAttack != null)
        {
            spellInventory.BasicAttackList.Add(spellInventory.BasicAttack);
            spellInventory.BasicAttack = null;
        }
    }
    


}
