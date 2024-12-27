using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    Inventory inventory;
    SpellInventory spellInventory;


    [Header("Items")]
    public bool spell;
    public bool boyOnce;

    //to sell items
    public GameObject item;
    public GameObject module;
    public int price;

     [Header("Other")]
     public TMP_Text PriceTMP;
     public TMP_Text ItemNameTMP;
     public Image image;


    void OnEnable()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        spellInventory = GameObject.Find("InventoryManager").GetComponent<SpellInventory>();


        //set graphics
        PriceTMP.text = ("Price : " + price);

        if (item != null)
        {
            ItemNameTMP.text = (item.GetComponent<ItemPickUp>().itemName);
        }
        else if (module != null)
        {
            ItemNameTMP.text = (module.GetComponent<GeneraldSpellModule>().itemName);
        }

        if (item != null)
        {
            image.sprite = Sprite.Create(item.GetComponent<ItemPickUp>().itemUiImage as Texture2D, new Rect(0, 0, item.GetComponent<ItemPickUp>().itemUiImage.width, item.GetComponent<ItemPickUp>().itemUiImage.height), new Vector2(0.5f, 0.5f));
        }
        else if (module != null)
        {
            // Assuming itemUiImage is a Texture, convert it to a Sprite
            image.sprite = Sprite.Create(module.GetComponent<GeneraldSpellModule>().itemUiImage as Texture2D, new Rect(0, 0, module.GetComponent<GeneraldSpellModule>().itemUiImage.width, module.GetComponent<GeneraldSpellModule>().itemUiImage.height), new Vector2(0.5f, 0.5f));
            
        }



    }


    
    public void buy() 
    {
        switch (spell)
        {
            case false:
                for (int i = 0; i < inventory.items.Length+1; i++)
                {
                    if (inventory.items[i].Items == null || inventory.items[i].Items == item && inventory.items[i].Amount < item.GetComponent<ItemPickUp>().MaxStack )
                    {
                        if (inventory.coin >= price) //checks if player has enough coin   
                        {
                            inventory.coin -= price; //takes the players coins
                            Inventory.Getitem(item);
                            bought();
                            break;
                        }
                    }
                }

            break;
            case true:

            bool contains = false;
            foreach (var item in spellInventory.Spells)
            {
                if (item == module)
                {   
                    contains = true;
                }
            }

            foreach (var item in spellInventory.spellsEuipe)
            {
                if (item == module)
                {   
                    contains = true;
                }
            }

            if (!contains && inventory.coin >= price)
            {
                inventory.coin -= price;
                spellInventory.Spells.Add(module);
                bought();
            }       

            break;
        }

    }

    void bought()
    {

        if (boyOnce)
        {
            this.gameObject.SetActive(false);
        }

    }


}
