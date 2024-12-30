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
    public GameObject DestoyDetector;

    ToolInventory inventory;

    public MagicTypes.Magictype magictype;

    void Start()
    {
        Invoke("EnableDestoy", 0.04f);
        
        inventory = GameObject.Find("GameManager").GetComponentInChildren<ToolInventory>();

        if (inventory.staffSlot != null)
        {
            if (inventory.staffSlot.GetComponent<itemUse>().damageModifer != 0 && itself == "Player")
            {
                Damage *= inventory.staffSlot.GetComponent<itemUse>().damageModifer;
            }
        }

    

    }

    //check if it hit anything and it is not the player
    public void OnTriggerEnter2D(Collider2D collision)
    {

        //here we check if it doesn't hit itself or a bullet or a wall 
        if(!collision.gameObject.CompareTag(itself) && collision.gameObject.CompareTag("Enemy") || !collision.gameObject.CompareTag(itself) && collision.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject); //destroy ball
            //here we what it hits 
            if (itself == "Player")
            {
                EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>(); //take the health script
                if (enemyHealth != null && !hit) //if there is non do nothing
                {
                    hit = true;
                    enemyHealth.TakeDamage(Damage, magictype);
                }

            }
            else if (itself == "Enemy")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                if (playerStats != null && !hit)
                {
                    hit = true;
                    playerStats.TakeDamage(Damage);
                }
            }
            

            
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); //destroy ball

        }

        
    }

    void EnableDestoy()
    {
        DestoyDetector.SetActive(true);
    }


}