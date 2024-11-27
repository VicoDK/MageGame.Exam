using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellSlotList : MonoBehaviour
{
    public static int EuipeSlot;
    public int slotNumber;
    SpellInventory spellInventory;
    GameObject spellList;
    public RawImage Image;
    public TMP_Text spellName;
    bool ones;

    void OnEnable()
    {
        spellInventory = GameObject.Find("GameManager").GetComponentInChildren<SpellInventory>();   
        spellList = GameObject.Find("SpellList");
        ones = true;
    }

    void Update()
    {
        if (ones)
        {
            Image.texture = spellInventory.Spells[slotNumber-1].transform.GetComponent<GeneraldSpellModule>().itemUiImage;
            spellName.text = (spellInventory.Spells[slotNumber-1].transform.GetComponent<GeneraldSpellModule>().itemName);
            ones = false;
        }
    }

    
    public void Equip()
    {
        spellInventory.Spells.Add(spellInventory.spellsEuipe[EuipeSlot-1]);
        spellInventory.spellsEuipe[EuipeSlot-1] = spellInventory.Spells[slotNumber-1]; // dont know how it would work but needs to change
        spellInventory.Spells.Remove(spellInventory.spellsEuipe[EuipeSlot-1]);
        spellInventory.Spells.RemoveAt(spellInventory.Spells.Count-1);
        spellList.SetActive(false);

    }
}
