using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{

    [Header("Values")]
    public float Damage;

    //check if it hit anything and it is not the player
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Wall"))
        {
            //make explosion and deleting magic ball
            collision.GetComponent<EnemyHealth>().TakeDamage(Damage, false);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            
        }
        
    }
}
