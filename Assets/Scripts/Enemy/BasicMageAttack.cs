using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class BasicMageAttack : MonoBehaviour
{
    //generald stats for basic attack
    [Header("General stats")]
    private Transform Player;
    public Transform FirePoint;
    public float Speed;
    public float AttackSpeed;

    [Header("Ball Attack")]
    public GameObject Ball;

    public bool StopShot;
    public RaycastHit2D Hit;
    public bool canShoot;
    EnemyHealth EnemyHealth;

    public LayerMask HitLayer;



    
    // Update is called once per frame
    void Start()
    {
        //find player
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyHealth = transform.parent.gameObject.GetComponent<EnemyHealth>();

        // start funktion
        InvokeRepeating("Attacks", 1, AttackSpeed);

    }

    void Update()
    {
        if (EnemyHealth.Alive)
        {
            Hit = Physics2D.Linecast(FirePoint.position, Player.position, HitLayer); //makes a line between enemy and player
        }
       
  
    }

    void Attacks()
    {
        
        //check if there is a player
        if (Player != null && Hit.collider.name == "PlayerBody" && !StopShot && canShoot)
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


        }


        
        
        
    }
}
