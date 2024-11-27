using UnityEngine;

public class itemUse : MonoBehaviour
{


    [Header("General use")]
    public bool canUse;
    public bool equip;

   


    public whatItem itemType;
    PlayerStats playerStats;

    [Header("Potion")]

    public int potionHealAmount;
    public int potionManaHealAmount;



    [Header("Stats")]

    [Header("staff Stats")]
    public float damageModifer;



    public MagicTypes.Magictype magicAffinity;
    public float magicAffinityModifier;
    public float manaRegenModifer;



    [Header("cloak Stats")]
    public float defence;
    

    public MagicTypes.Magictype magicResistens;

    
    public MagicTypes.Magictype magicWaekness;

    //public float speedModifier;



    public void UseItem(int SlotNumber)
    {
        if (canUse && itemType == whatItem.HealthPotion)
        {
            HealthPotion(SlotNumber);
        }
        else  if (canUse && itemType == whatItem.ManaPotion)
        {
            ManaPotion(SlotNumber);
        }
        else 
        {
            Debug.Log("no effect");
        }


    }


    public void HealthPotion(int SlotNumber)
    {   
        playerStats = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        
        if (playerStats.Health < playerStats.MaxHealth)
        {
            GameObject.Find("InventoryManager").GetComponent<Inventory>().items[SlotNumber-1].Amount--;
            playerStats.Health += potionHealAmount;
            playerStats.HealthBar.fillAmount = playerStats.Health / playerStats.MaxHealth;
        }

    }

    public void ManaPotion(int SlotNumber)
    {   

        playerStats = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        
        if (playerStats.Mana < playerStats.MaxMana)
        {

            GameObject.Find("InventoryManager").GetComponent<Inventory>().items[SlotNumber-1].Amount--;
            playerStats.Mana += potionManaHealAmount;
            playerStats.ManaBar.fillAmount = playerStats.Mana / playerStats.MaxMana;
        }

    }

     public enum whatItem
    {
        None,
        HealthPotion,
        ManaPotion,
        Cloak,
        Staff
        
    }
}
