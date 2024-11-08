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

    public void UseItem()
    {
        if (canUse && itemType == whatItem.HealthPotion)
        {
            HealthPotion();
        }
        else 
        {
            Debug.Log("no effect");
        }


    }


    public void HealthPotion()
    {
        playerStats = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        playerStats.Health += potionHealAmount;

    }
}
