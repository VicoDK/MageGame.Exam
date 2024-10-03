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
    public bool BurningEffect;
    public bool FrozenEffect;
    public bool WetEffect;

    [Header("Magic Type")]
    public bool FireMagic;
    public bool IceMagic;
    public bool LightingMagic;
    public bool WindMagic;
    public bool plantMagic;
    public bool RockMagic;
    public bool WaterMagic;
    public bool EnergyMagic;
    
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
            collision.GetComponent<EnemyHealth>().TakeDamage(Damage, LightingMagic);
            
            //here we check which effect to give
            if(BurningEffect)
            {
                collision.GetComponent<EnemyHealth>().Bruning();
            }
            else if(FrozenEffect)
            {
                collision.GetComponent<EnemyHealth>().Frozen();
            }
            else if(WetEffect)
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
