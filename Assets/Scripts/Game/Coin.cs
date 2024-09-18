using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Coin : MonoBehaviour
{
    //speed of coin when dropped
    public float Speed;

    //direction and angle of coin when dropped
    public Vector2 fireDir;
    PlayerStats PlayerStat;



	void Start () 
    {
        //random direction and angle
        fireDir.y = Random.Range(-3f, 3f);
        fireDir.x = Random.Range(-3f, 3f);
      
        //calculate the angel to fire the coind
        float angle = Mathf.Atan2(fireDir.y+2f, fireDir.x+ 2f) * Mathf.Rad2Deg; 
        //Change the dir of the coins
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // get the rb and Add force to the coin
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(fireDir * Speed, ForceMode2D.Impulse);

        PlayerStat = GetComponent<PlayerStats>();

	}

    //colliding with something
void OnTriggerEnter2D(Collider2D collision)
{
    //if player
    if (collision.gameObject.CompareTag("Player"))
    {
        // Get the PlayerStats component from the player object
        PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            // Give player coins and destroy coin
            playerStats.Coin++;
            Destroy(gameObject);
        }
    }
}
}
