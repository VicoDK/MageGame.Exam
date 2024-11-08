using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Values")]
    public float Time;
   
   public float Damage;

    [Header("Magic Effect")]
    /*public bool BurningEffect;
    public bool FrozenEffect;
    public bool WetEffect;*/
    public magicEffects magicEffect;
    public enum magicEffects
    {
        BurningEffect,
        FrozenEffect,
        WetEffect,
        none
    }


    [Header("Magic Type")]
    /*public bool FireMagic;
    public bool IceMagic;
    public bool LightingMagic;
    public bool WindMagic;
    public bool plantMagic;
    public bool RockMagic;
    public bool WaterMagic;
    public bool EnergyMagic;*/
    public magicTypes magicType;
    public enum magicTypes
    {
        FireMagic,
        IceMagic,
        LightingMagic,
        WindMagic,
        plantMagic,
        RockMagic,
        WaterMagic,
        EnergyMagic
    }


    [Header("Effects")]
    public float frezeTime;
    
    void Start()
    {
        //here we start det Explosion timer
        StartCoroutine(Explode());
    }

    //here we check if there is a collsion and if its the player
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            
            //here we find a script whit the name EnemyHealth and  the function TakeDamage and give it our value Damage

            if (magicType == magicTypes.LightingMagic)
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(Damage, magicType);   
            }
            else if (magicType == magicTypes.IceMagic)
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(Damage, frezeTime, magicType);  
            }
            else 
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(Damage);   
            }
            
            //here we check which effect to give
            if(magicEffect == magicEffects.BurningEffect)
            {
                collision.GetComponent<EnemyHealth>().Bruning();
            }
            else if(magicEffect == magicEffects.FrozenEffect)
            {
                collision.GetComponent<EnemyHealth>().Frozen();
            }
            else if(magicEffect == magicEffects.WetEffect)
            {
                collision.GetComponent<EnemyHealth>().Wet();
            }
             
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(Damage);
        }
        
    }
    private IEnumerator Explode()
    {
        //here we wait some seconds
        yield return new WaitForSeconds(Time);
        //here we destroy the explosion after some time
        Destroy(gameObject);
        
    }

}
