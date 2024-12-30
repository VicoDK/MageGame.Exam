using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    
    [Header("Health")]
    public float Health; 
    public bool Alive = true; 
    
    public float MaxHealth;
    public float HealthRegn; 
    public float HealthRegnDelay;
    private bool AllowHeal = true;

    private float healTime;



    private bool BurningEffect;
    public float BurnDamage;
    public float BurnTimer;
    public int BurnEffectLength;
    private float Burntimestamp1;
        private int BurnTicks;

    [Header("UI")]
    public GameObject DeathMenu;

    [Header("Mana")]
    public  float Mana; 
    public float MaxMana;
    public float ManaRegn; 
    private bool AllowMana;
     public float manaRegnDelay;

     private float ManaTime;

    [Header("Mana and Health bars")]
    public Image HealthBar;
    public Image ManaBar;


    public bool Shopping; 
    private SpriteRenderer Sprite;
    private bool ones;


    ToolInventory Inventory;
    itemUse CloakStat;

    public float DamageWeaknessModifier;
    public float DamageResistensModifier;

 

    void Start()
    {
        Shopping = false;
        
        MaxMana = Mana;
        MaxHealth = Health;

        Sprite = GetComponent<SpriteRenderer>();
        Inventory = GameObject.Find("GameManager").GetComponentInChildren<ToolInventory>();
        //CloakStat = Inventory.cloakSlot.gameObject.GetComponent<ItemUse>();
        
    }   

    void Update()
    {
        //makes xTime count down 
        healTime -= Time.deltaTime;  
        ManaTime -= Time.deltaTime;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }



        //burning
        if (BurningEffect)
        {   
            ones = false;
            
            GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 125); 

            //the enemy takes some damage every few second and counts it 
            if (Time.time >= Burntimestamp1)
            {
                TakeDamage(BurnDamage);
                Burntimestamp1 = Time.time + BurnTimer;
                BurnTicks++;
            }

            //if the burnticks is over BurnEffectLength, then the burning stops
            if (BurnTicks >= BurnEffectLength)
            {
                if (!ones)
                {
                    GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255); 
                    ones = true;
                }
                
                BurnTicks = 0;
                BurningEffect = false;
            }


        }


    }

    void FixedUpdate()
    {

        //runs when the time for regen to started runned out
        if (healTime < 0f)
        {
            //starts the players healing
            AllowHeal = true;

        }

        //runs when the time for mana regen to started runned out
        if (ManaTime < 0f)
        {

            //starts the players mana regen
            AllowMana = true;

        }
    
        //this is for mana regn
        if (MaxMana > Mana && Alive && AllowMana)
        {   

            if (Inventory.staffSlot != null)
            {
                if (Inventory.staffSlot.GetComponent<itemUse>().manaRegenModifer != 0)
                {
                    Mana += (ManaRegn/50) * Inventory.staffSlot.GetComponent<itemUse>().manaRegenModifer;
                }
                else 
                {

                    Mana += (ManaRegn/50);
                }
            }
            else
            {

                Mana += (ManaRegn/50);
            }
        }

        //this is for health regn
        if (Health < 0 || Health == 0)
        {
            Alive = false;
        }
        else if (MaxHealth > Health && AllowHeal)
        {
            Health += HealthRegn/50;
        }

        //this is to update health and mana bar
        HealthBar.fillAmount = Health / MaxHealth;
        ManaBar.fillAmount = Mana / MaxMana;

        if (!Alive)
        {
                       
            DeathMenu.SetActive(true);
            Sprite.enabled = false;
            Controls.PInput.DeactivateInput(); 
            Time.timeScale = 0;
            //Destroy(gameObject);
        }


        //for updating layout with coins 
        //CoinAmountDisplay.text = (Coin + " ");
    }

    //function for taking damage
    public void TakeDamage(float Damage)
    {
        
        if (Inventory.cloakSlot.GetComponent<itemUse>().defence != 0 && Inventory.cloakSlot != null)
        {
        Health -= Damage * Inventory.cloakSlot.GetComponent<itemUse>().defence;

        }
        else 
        {
            Health -= Damage;
        }

         //stops the player from healing
        AllowHeal = false;

        //set the timer to HealthRegnDelay
        healTime = HealthRegnDelay;  

    } 

    //enemy damage
    public void TakeDamage(float Damage, MagicTypes.magicEffects magicEffects, MagicTypes.Magictype magictype)
    {
        if (Inventory.cloakSlot.GetComponent<itemUse>().magicWaekness == magictype)
        {
            if (Inventory.cloakSlot.GetComponent<itemUse>().defence != 0 && Inventory.cloakSlot != null)
            {
                Health -= (Damage * Inventory.cloakSlot.GetComponent<itemUse>().defence) * DamageWeaknessModifier;

            }
            else 
            {
                Health -= Damage;
            }

        }
        else if (Inventory.cloakSlot.GetComponent<itemUse>().magicResistens == magictype)
        { 
            if (Inventory.cloakSlot.GetComponent<itemUse>().defence != 0 && Inventory.cloakSlot != null)
            {
                Health -= (Damage * Inventory.cloakSlot.GetComponent<itemUse>().defence) * DamageResistensModifier;

            }
            else 
            {
                Health -= Damage;
            }

        }
        else 
        {
            if (Inventory.cloakSlot.GetComponent<itemUse>().defence != 0 && Inventory.cloakSlot != null)
            {
                Health -= Damage * Inventory.cloakSlot.GetComponent<itemUse>().defence;

            }
            else 
            {
                Health -= Damage;
            }
        }


         //stops the player from healing
        AllowHeal = false;

        //set the timer to HealthRegnDelay
        healTime = HealthRegnDelay;

        switch (magicEffects)
        {

            case MagicTypes.magicEffects.BurningEffect:
            BurningEffect = true;

            break;
            default:
            break;

        }


        

    } 

    //self damage
    public void TakeDamage(float Damage, MagicTypes.magicEffects magicType, bool selfDamage)
    {

        Health -= Damage;

         //stops the player from healing
        AllowHeal = false;

        //set the timer to HealthRegnDelay
        healTime = HealthRegnDelay;

        switch (magicType)
        {

            case MagicTypes.magicEffects.BurningEffect:
            BurningEffect = true;

            break;
            default:
            break;

        }


        

    } 

    public void ManaCost()
    {
        // stops for mana regen
        AllowMana = false;

        //set the timer to manaRegnDelay
        ManaTime = manaRegnDelay;

    }
}
