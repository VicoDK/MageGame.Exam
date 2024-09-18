using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    
    
    
    [Header("Player purse")]
    public float Coin; //static

    public TMP_Text CoinAmountDisplay;
    

    [Header("Health")]
    public float Health; //static
    public bool Alive = true; //static
    
    private float MaxHealth;
    public float HealthRegn; //static
    public float HealthRegnDelay;
    private bool AllowHeal = true;

    [Header("UI")]
    public GameObject DeathMenu;

    [Header("Mana")]
    public  float Mana; //static
    private float MaxMana;
    public float ManaRegn; //static

    [Header("Mana and Health bars")]
    public Image HealthBar;
    public Image ManaBar;


    public bool Shopping; //static

 

    void Start()
    {
        Shopping = false;
        
        MaxMana = Mana;
        MaxHealth = Health;
        
    }   

    void FixedUpdate()
    {

        //this is for mana regn
        if (MaxMana > Mana && Alive)
        {
            Mana += ManaRegn;
        }

        //this is for health regn
        if (Health < 0 || Health == 0)
        {
            Alive = false;
        }
        else if (MaxHealth > Health && AllowHeal)
        {
            Health += HealthRegn;
        }

        //this is to update health and mana bar
        HealthBar.fillAmount = Health / MaxHealth;
        ManaBar.fillAmount = Mana / MaxMana;

        if (!Alive)
        {
                       
            DeathMenu.SetActive(true);
            Destroy(gameObject);
        }


        //delete before realese
        //
        //
        //
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Mana = MaxMana;
        }


        //for updating layout with coins 
        CoinAmountDisplay.text = (Coin + " Coins");
    }

    //function for taking damage
    public void TakeDamage(float Damage)
    {

        Health -= Damage;

        //start heal delay timer
        StartCoroutine(Attacks());

        

    } 

    //heal delay timer
    private IEnumerator Attacks ()
    {
        //stops the player from healing
        AllowHeal = false;
        //here we wait some seconds
        yield return new WaitForSeconds(HealthRegnDelay);
        //starts the players healing
        AllowHeal = true;
        
    }


}
