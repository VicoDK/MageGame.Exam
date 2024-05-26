using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    [Header("Health")]
    public bool Alive;
    public float _Health;
    public static float Health;
    private float MaxHealth;
    public float _HealthRegn;
    public static float HealthRegn;
    public float HealthRegnDelay;
    private bool AlowHeal = true;

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

    void Start()
    {
        //here we set the static variables to the orther variabels
        Health = _Health;
        HealthRegn = _HealthRegn;
        MaxHealth = _Health;
        Mana = _Mana;
        MaxMana = _Mana;
        ManaRegn = _ManaRegn;
    }   

    void FixedUpdate()
    {
        //this wil allow to see the static variabels
        _Health = Health;
        _HealthRegn = HealthRegn;
        _Mana = Mana;
        _ManaRegn = ManaRegn;


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
        else if (MaxHealth > Health && AlowHeal)
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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Mana = MaxMana;
        }
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
        AlowHeal = false;
        //here we wait some seconds
        yield return new WaitForSeconds(HealthRegnDelay);
        //starts the players healing
        AlowHeal = true;
        
    }


}
