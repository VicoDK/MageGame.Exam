using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BasicMageAttack : MonoBehaviour
{
    //generald stats for basic attack
    [Header("General stats")]
    public Transform Player;
    public Transform FirePoint;
    public float Speed;
    public float Timer;

    [Header("Ball Attack")]
    public GameObject Ball;

    
    // Update is called once per frame
    void Start()
    {
        //find player
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        // start funktion
        StartCoroutine(Attacks());

    }

    IEnumerator Attacks()
    {
        //check if there is a player
        if (Player != null)
        {
            //all the code made from line 19 to 45 is made by ChatGBT (with some small changes) with this promt "make a script for unity2d, where the players mouse is fire a object there"
            // Get mouse position
            Vector3 PlayerPosition = Player.transform.position;
            PlayerPosition.z = 0f;

            // Calculate direction towards mouse position
            Vector2 fireDir = (PlayerPosition - transform.position).normalized;

            // Instantiate bullet at fire point
            GameObject bullet = Instantiate(Ball, FirePoint.position, Quaternion.identity);

            // Rotate bullet towards mouse position
            float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(fireDir * Speed, ForceMode2D.Impulse);

            //wait some seconds
            yield return new WaitForSeconds(Timer);

            //Start function all over again
            StartCoroutine(Attacks());
        }
        
    }
}
