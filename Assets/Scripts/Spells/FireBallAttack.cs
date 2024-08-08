using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FireBallAttack : MonoBehaviour
{
    [Header("General stats")]
    public Transform FirePoint;
    public float Speed;
    public int ManaCost;
    private GameObject bullet;


    [Header("Ball Attack")]
    public GameObject Ball;
    public GameObject explosionPrefab;



    // Update is called once per frame
    void Update()
    {
        //ball attacks
        //rigistere input
        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerStats.Mana >= ManaCost && Attack.AttackReady && !PlayerStats.Shopping)
        {
            //all the code made from line 19 to 45 is made by ChatGBT (with some small changes) with this promt "make a script for unity2d, where the players mouse is fire a object there"
            // Get mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calculate direction towards mouse position
            Vector2 fireDir = (mousePosition - transform.position).normalized;

            // Instantiate bullet at fire point
            bullet = Instantiate(Ball, FirePoint.position, Quaternion.identity);

            // Rotate bullet towards mouse position
            float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(fireDir * Speed, ForceMode2D.Impulse);


            // add the explodion prefab and destroy bullet
            Invoke("ReplaceBullet", Vector2.Distance(transform.position, mousePosition) / Speed);

            //mana cost
            PlayerStats.Mana -= ManaCost;

            StartCoroutine(Attack.AttackDelay());

        }
    }

    void ReplaceBullet()
    {
        // Find the bullet and replace it with explosion prefab
        //GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
        if (bullet != null)
        {
            //Instantiate explosion prefab at bullet position
            Instantiate(explosionPrefab, bullet.transform.position, Quaternion.identity);
            Destroy(bullet);
        }

    }
}
