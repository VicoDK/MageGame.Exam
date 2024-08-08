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
    public static float CoinAmount; 
    static public int Coin;
    public TMP_Text CoinAmountDisplay;
    

    [Header("Health")]
    public float _Health;
    public static float Health;
    static public bool Alive = true;
    
    private float MaxHealth;
    public float _HealthRegn;
    public static float HealthRegn;
    public float HealthRegnDelay;
    private bool AllowHeal = true;

    [Header("UI")]
    public GameObject DeathMenu;

    [Header("Mana")]
    public float _Mana;
    public static float Mana;
    private float MaxMana;
    public float _ManaRegn;
    public static float ManaRegn;

    [Header("Mana and Health bars")]
    public Image HealthBar;
    public Image ManaBar;


    public static bool Shopping;

 

    void Start()
    {
        //here we set the static variables to the orther variabels
        Health = _Health;
        HealthRegn = _HealthRegn;
        MaxHealth = _Health;
        Mana = _Mana;
        MaxMana = _Mana;
        ManaRegn = _ManaRegn;
        Shopping = false;

        
    }   

    void FixedUpdate()
    {
        //this wil allow to see the static variabels
        _Health = Health;
        _HealthRegn = HealthRegn;
        _Mana = Mana;
        _ManaRegn = ManaRegn;
        CoinAmount = Coin;


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
        CoinAmountDisplay.text = (CoinAmount + " Coins");
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
