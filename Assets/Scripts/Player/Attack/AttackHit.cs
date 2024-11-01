using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject explosionPrefab;

    private bool hasExploded = false; // Add a boolean flag

    BallAttack ballAttack;



    void Start()
    {
        ballAttack = GameObject.Find("PlayerBody").GetComponent<BallAttack>(); //stores the player BallAttack script
        Invoke("ReplaceBullet", Vector2.Distance(transform.position, ballAttack.mousePosition) / ballAttack.Speed); //invokes a function to destroy the fire ball after it has hit i distanation
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