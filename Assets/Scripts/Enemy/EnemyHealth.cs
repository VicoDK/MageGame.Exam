using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    
    
    [Header("Stats")]
    public float Health = 100;

    private float MaxHealth;

    //Generald info
    private bool BurningEffect;
    private bool FrozenEffect;
    private bool WetEffect;

    [Header("Effect Damage + Effect Timer")]

    [Header("Effect Multiplier")]
    public float LightingOnWetEnemy;

    [Header("Burning Effect")]
    public float BurnDamage;
    public float BurnTimer;
    public int BurnEffectLength;
    private float Burntimestamp1;
    private int BurnTicks;

    public Image HealthBar;


    //function for taking damage
    public void TakeDamage(float Damage, bool LightingMagic)
    {   
        //check if enemy is wet and there is used LightingMagic 
        if (WetEffect && LightingMagic)
        {
            //take damage more damage
            Health -= Damage*LightingOnWetEnemy;
        }
        else 
        {
            //take damage
            Health -= Damage;
        }

    } 


    //function for burning enemy
    public void Bruning()
    {
        //if enemy is not wet or forzen 
        if (!WetEffect && !FrozenEffect)
        {
            //enemy is burning 
            BurningEffect = true;
        }
        else
        {
            //if they were wet or frozen, now they are dry
            WetEffect = false;
            FrozenEffect = false;
        }
        
    }

    //function to frezze the enemy
    public void Frozen()
    {
        //enemy is frozen  (but not wet)  (but not burning)
        FrozenEffect = true;
        WetEffect = false;
        BurningEffect = false;
    }

    //function for making the enemy wet
    public void Wet()
    {
        //if enemy is not burning or forzen 
        if (!BurningEffect && !FrozenEffect)
        {
            //make them wet
            WetEffect = true;
        }
        else if (BurningEffect) //if burning dry them
        {
            BurningEffect = false;

        }
        else if (FrozenEffect) // frozen do nothing
        {
            //Do nothing
        }
    }

    void Update()
    {


        //check if enemy is dead
        if (Health < 0 || Health == 0)
        {
            Destroy(gameObject);
        }


        //here we see what effect we should do
        if (BurningEffect)
        {
            //turn player red
            GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 125); 

            //the enemy takes some damage every few second and counts it 
            if (Time.time >= Burntimestamp1)
            {
                TakeDamage(BurnDamage, false);
                Burntimestamp1 = Time.time + BurnTimer;
                BurnTicks++;
            }

            //if the burnticks is over BurnEffectLength, then the burning stops
            if (BurnTicks >= BurnEffectLength)
            {
                BurnTicks = 0;
                BurningEffect = false;
            }


        }
        else if (FrozenEffect) 
        {
            //make them change color to frozen
            GetComponent<SpriteRenderer>().color = new Color (0, 146, 241, 125); 

        }
        else if (WetEffect)
        {
            //make them change color to wet
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 255, 125); 

        }
        else if (!BurningEffect && !FrozenEffect && !WetEffect)
        {
            //make them change color to normal
            GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255); 


        }
    }

    void FixedUpdate()
    {
        HealthBar.fillAmount = Health / MaxHealth;


    }

    void Start()
    {
        MaxHealth = Health;
    }
}