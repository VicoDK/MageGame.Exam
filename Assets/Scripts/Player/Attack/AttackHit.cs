using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject explosionPrefab;


    //check if it hit anything and it is not the player
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet"))
        {
            //make explosion and deleting magic ball
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        
    }
}
