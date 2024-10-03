using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{

    [Header("Values")]
    public float Damage;
    public String itself;

    bool hit = false;


    //check if it hit anything and it is not the player
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //here we check if it doesn't hit itself or a bullet or a wall 
        if(!collision.gameObject.CompareTag(itself) && !collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("DontHit")) 
        {
            Destroy(gameObject); //destroy ball
            //here we what it hits 
            if (itself == "Player")
            {
                EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>(); //take the health script
                if (enemyHealth != null && !hit) //if there is non do nothing
                {
                    hit = true;
                    enemyHealth.TakeDamage(Damage, false);
                }

            }
            else if (itself == "Enemy")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(Damage);
                }
            }
            

            
        }

   
  
        
        
    }
}