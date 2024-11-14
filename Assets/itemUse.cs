using UnityEngine;

public class itemUse : MonoBehaviour
{
    /* have alot of function (itemuses)
    check which item it is and then run it
    if the item dont have any uses dont do anything
    */

    [Header("General use")]
    public bool canUse;

    public enum whatItem
    {
        None,
        HealthPotion
        
    }

    public whatItem itemType;
    PlayerStats playerStats;

    [Header("Potion")]

    public int potionHealAmount;

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
        GameObject.Find("CanvasG").GetComponent<Inventory>().items[SlotNumber-1].Amount--;
        playerStats.Health += potionHealAmount;

    }
}
