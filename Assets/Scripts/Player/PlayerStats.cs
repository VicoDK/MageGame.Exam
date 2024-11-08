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
    
    private float MaxHealth;
    public float HealthRegn; 
    public float HealthRegnDelay;
    private bool AllowHeal = true;

    private float healTime;

    [Header("UI")]
    public GameObject DeathMenu;

    [Header("Mana")]
    public  float Mana; 
    private float MaxMana;
    public float ManaRegn; 
    private bool AllowMana;
     public float manaRegnDelay;

     private float ManaTime;

    [Header("Mana and Health bars")]
    public Image HealthBar;
    public Image ManaBar;


    public bool Shopping; 
    private SpriteRenderer Sprite;
    private PlayerInput  pInput;

 

    void Start()
    {
        Shopping = false;
        
        MaxMana = Mana;
        MaxHealth = Health;

        Sprite = GetComponent<SpriteRenderer>();
        //pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
        
    }   

    void Update()
    {
        //makes xTime count down 
        healTime -= Time.deltaTime;  
        ManaTime -= Time.deltaTime;


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
            Mana += ManaRegn/50;
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
            pInput.DeactivateInput(); 
            Time.timeScale = 0;
            //Destroy(gameObject);
        }


        //for updating layout with coins 
        //CoinAmountDisplay.text = (Coin + " ");
    }

    //function for taking damage
    public void TakeDamage(float Damage)
    {

        Health -= Damage;

         //stops the player from healing
        AllowHeal = false;

        //set the timer to HealthRegnDelay
        healTime = HealthRegnDelay;


        

    } 

    public void ManaCost()
    {
        // stops for mana regen
        AllowMana = false;

        //set the timer to manaRegnDelay
        ManaTime = manaRegnDelay;

    }
}
