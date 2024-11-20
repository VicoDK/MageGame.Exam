using UnityEngine;

public class itemUse : MonoBehaviour
{
    /* have alot of function (itemuses)
    check which item it is and then run it
    if the item dont have any uses dont do anything
    */

    [Header("General use")]
    public bool canUse;
    public bool equip;

   


    public whatItem itemType;
    PlayerStats playerStats;

    [Header("Potion")]

    public int potionHealAmount;



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
            GameObject.Find("Inventory").GetComponent<Inventory>().items[SlotNumber-1].Amount--;
            playerStats.Health += potionHealAmount;
            playerStats.HealthBar.fillAmount = playerStats.Health / playerStats.MaxHealth;
        }

    }

     public enum whatItem
    {
        None,
        HealthPotion,
        Cloak,
        Staff
        
    }
}
