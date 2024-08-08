using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject explosionPrefab;

    private bool hasExploded = false; // Add a boolean flag

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
}