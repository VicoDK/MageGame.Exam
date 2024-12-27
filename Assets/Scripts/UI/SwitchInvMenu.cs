using UnityEngine;
using TMPro;

public class SwitchInvMenu : MonoBehaviour
{
    public GameObject ItemInv;
    public GameObject SpellInv;

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
        SpellInv.SetActive(false);
    }

    public void GoToSpellInv()
    {
        ItemInv.SetActive(false);
        SpellInv.SetActive(true);
    }

    /*void OnEnable()
    {
        ItemInv.SetActive(true);
        SpellInv.SetActive(false);
    }*/
}
