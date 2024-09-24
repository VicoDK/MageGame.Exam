using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePickup : MonoBehaviour
{
    //speed of coin when dropped
    public float speed;

    //direction and angle of coin when dropped
    private Vector2 fireDir;


	void Start () 
    {
        //random direction and angle
        fireDir.y = Random.Range(-3f, 3f);
        fireDir.x = Random.Range(-3f, 3f);
      
        //calculate the angel to fire the coin
        float angle = Mathf.Atan2(fireDir.y+2f, fireDir.x+ 2f) * Mathf.Rad2Deg; 
        //Change the dir of the coins
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // get the rb and Add force to the coin
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(fireDir * speed, ForceMode2D.Impulse);

	}

    //colliding with something
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if player
        if(collision.gameObject.CompareTag("Player"))
        {
            //Give player coins and destroy coin
            //PlayerStats.Slime++;
            Destroy(gameObject);
        }
    }
}