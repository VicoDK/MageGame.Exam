using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellSlotInstantiate : MonoBehaviour
{
    public GameObject SpellSlot;

    SpellInventory spellInventory;

    void OnEnable()
    {
        spellInventory = GameObject.Find("GameManager").GetComponentInChildren<SpellInventory>();





        for (int i = 0; i < spellInventory.Spells.Count; i++) 
        {
            GameObject Slot = Instantiate(SpellSlot, this.transform);
            Slot.GetComponent<SpellSlotList>().slotNumber = i+1;


        }
    }
    void OnDisable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

    }

    




}
