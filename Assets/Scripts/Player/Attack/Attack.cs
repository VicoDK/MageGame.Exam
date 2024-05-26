using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [Header("Player Input System")]
    //add new input system
    [Header("Fire Point")]
    public Transform FirePoint;

    [Header("Prefabs")]
    [Header("Base Attack")]
    public GameObject BaseAttack;

    [Header("Meleattack")]
    public GameObject Sword;

    [Header("Projectile Speed")]
    public float Speed;
    
    void Update()
    {
        //base attack
        if (Input.GetButtonDown("Fire1"))
        {
            //all the code made from line 19 to 45 is made by ChatGBT (with some small changes) with this promt "make a script for unity2d, where the players mouse is fire a object there"
            // Get mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calculate direction towards mouse position
            Vector2 fireDir = (mousePosition - transform.position).normalized;

            // Instantiate bullet at fire point
            GameObject bullet = Instantiate(BaseAttack, FirePoint.position, Quaternion.identity);

            // Rotate bullet towards mouse position
            float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(fireDir * Speed, ForceMode2D.Impulse);

        }

    }

}
