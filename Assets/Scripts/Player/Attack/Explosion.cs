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
    public MagicTypes.magicEffects magicEffect;


    [Header("Magic Type")]

    public MagicTypes.Magictype magicType;


    [Header("Effects")]
    public float frezeTime;

    Inventory inventory;
    
    void Start()
    {
        //here we start det Explosion timer
        StartCoroutine(Explode());

        inventory = GameObject.Find("GameManager").GetComponentInChildren<Inventory>();
        if (inventory.staffSlot.GetComponent<itemUse>().damageModifer != 0)
        {
            if (inventory.staffSlot.GetComponent<itemUse>().magicAffinity == magicType)
            {
                Damage *= inventory.staffSlot.GetComponent<itemUse>().damageModifer * inventory.staffSlot.GetComponent<itemUse>().magicAffinityModifier;
            }
            else
            {
                Damage *= inventory.staffSlot.GetComponent<itemUse>().damageModifer;
            }
        }
    }

    //here we check if there is a collsion and if its the player
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            
            //here we find a script whit the name EnemyHealth and  the function TakeDamage and give it our value Damage

            if (magicType == MagicTypes.Magictype.LightingMagic)
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(Damage, magicType);   
            }
            else if (magicType == MagicTypes.Magictype.IceMagic)
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(Damage, frezeTime, magicType);  
            }
            else if (magicType == MagicTypes.Magictype.WaterMagic)
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(Damage, magicType);  
            }
            else 
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(Damage);   
            }
            
            //here we check which effect to give
            if(magicEffect == MagicTypes.magicEffects.BurningEffect)
            {
                collision.GetComponent<EnemyHealth>().Bruning();
            }
            else if(magicEffect == MagicTypes.magicEffects.FrozenEffect)
            {
                collision.GetComponent<EnemyHealth>().Frozen();
            }
            else if(magicEffect == MagicTypes.magicEffects.WetEffect)
            {
                collision.GetComponent<EnemyHealth>().Wet();
            }
             
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(Damage, magicEffect, true);
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
