using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject explosionPrefab;

    private bool hasExploded = false; // Add a boolean flag

    FireBallAttack FireBallAttack;



    void Start()
    {
        FireBallAttack = GameObject.Find("PlayerBody").GetComponent<FireBallAttack>(); //stores the player FireBallAttack script
        Invoke("ReplaceBullet", Vector2.Distance(transform.position, FireBallAttack.mousePosition) / FireBallAttack.Speed); //invokes a function to destroy the fire ball after it has hit i distanation
    }

    // Check if it hit anything and it is not the player
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasExploded && (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))) 
        {
            // Make explosion and deleting magic ball
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            hasExploded = true; // Set the flag to true
        }
    }


    void ReplaceBullet()
    {


        
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);//Instantiate explosion prefab at bullet position
        Destroy(gameObject); //destroys the fireball
        

    }
}