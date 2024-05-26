using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    
    [Header("Stats")]
    public float Health = 100;

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


    //function for taking damage
    public void TakeDamage(float Damage, bool LightingMagic)
    {
        if (WetEffect && LightingMagic)
        {
            //take damage
            Health -= Damage*LightingOnWetEnemy;
        }
        else 
        {
            Health -= Damage;
        }

    } 


    //function for burning enemy
    public void Bruning()
    {
        
        if (!WetEffect && !FrozenEffect)
        {
            BurningEffect = true;
        }
        else
        {
            
            WetEffect = false;
            FrozenEffect = false;
        }
        
    }

    //function to frezze the enemy
    public void Frozen()
    {
        FrozenEffect = true;
        WetEffect = false;
        BurningEffect = false;
    }

    //function for making the enemy wet
    public void Wet()
    {
        if (!BurningEffect && !FrozenEffect)
        {
            WetEffect = true;
        }
        else if (BurningEffect)
        {
            BurningEffect = false;

        }
        else if (FrozenEffect)
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
            GetComponent<SpriteRenderer>().material.color = new Color (255, 0, 0, 255); 

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
            GetComponent<SpriteRenderer>().material.color = new Color (0, 146, 241, 255); 
            Debug.Log("frozen");
        }
        else if (WetEffect)
        {
            GetComponent<SpriteRenderer>().material.color = new Color (0, 0, 255, 255); 
            Debug.Log("wet");
        }
        else if (!BurningEffect && !FrozenEffect && !WetEffect)
        {
            GetComponent<SpriteRenderer>().material.color = new Color (255, 255, 255, 255); 
            //Debug.Log("normal");

        }
    }
}