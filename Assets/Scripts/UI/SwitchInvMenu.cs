using UnityEngine;
using TMPro;

public class SwitchInvMenu : MonoBehaviour
{
    public GameObject ItemInv;
    public GameObject SpellInv;
    public GameObject ToolInv;

    public TMP_Text[] invCoins;

    Inventory inventory; 


    void Update()
    {
        if (inventory == null)
        {
            inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        }

        foreach (var item in invCoins)
        {
            item.text = (inventory.coin + " ");
        }
    }
    public void GoToItemInv()
    {
        ItemInv.SetActive(true);
        ToolInv.SetActive(false);
        SpellInv.SetActive(false);
    }

    public void GoToSpellInv()
    {
        ItemInv.SetActive(false);
        ToolInv.SetActive(false);
        SpellInv.SetActive(true);
    }

        public void GoToToolInv()
    {
        ItemInv.SetActive(false);
        ToolInv.SetActive(true);
        SpellInv.SetActive(false);
    }

    /*void OnEnable()
    {
        ItemInv.SetActive(true);
        SpellInv.SetActive(false);
    }*/
}
