using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [Header("Player Input System")]

    private Transform FirePoint;

    [Header("Basic attack")]
    public float Speed;
    public GameObject BaseAttack;
    public float Delay = 0.2f;
    PlayerStats PlayerStat;
    Vector2 fireDir;
    Movment movement;
    Controls controls;
    Vector3 mousePosition;

    public void Fire()
    {
        if (PlayerStat == null || movement == null  || FirePoint == null ||controls == null) 
        {
            PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
            movement = GameObject.Find("PlayerBody").GetComponent<Movment>();
            FirePoint = GameObject.Find("PlayerFirePoint").GetComponent<Transform>();
            controls = GameObject.Find("PlayerBody").GetComponent<Controls>();

        }


        //base attack
        //here we check after input and if attack is ready
        if (controls.AttackReady && !PlayerStat.Shopping && movement.canMove)
        {
            if (Controls.PInput.actions["Fire"].WasPressedThisFrame()) //Mouse input
            {
                //all the code made from line 19 to 45 is made by ChatGBT (with some small changes) with this promt "make a script for unity2d, where the players mouse is fire a object there"
                // Get mouse position
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;

                // Calculate direction towards mouse position
                fireDir = (mousePosition - FirePoint.position).normalized;
            }
            else if (Controls.PInput.actions["FireController"].WasPressedThisFrame()) //Controller input
            { 
                fireDir = Controls.PInput.actions.FindAction("FireDIR").ReadValue<Vector2>();// read FireDIR
                
                if (fireDir.x == 0f && fireDir.y == 0f) //make sure that the player aims
                {
                    
                    if (Controls.PInput.actions.FindAction("Move").ReadValue<Vector2>().x == 0 && Controls.PInput.actions.FindAction("Move").ReadValue<Vector2>().y == 0) //checks if player is moving
                    {
                        fireDir = Vector2.right; //if they dont
                    }
                    else 
                    {
                        fireDir = Controls.PInput.actions.FindAction("Move").ReadValue<Vector2>(); //if they move
                    }
                }

            }
            

            // Instantiate bullet at fire point
            GameObject bullet = Instantiate(BaseAttack, FirePoint.position, Quaternion.identity);
            
            // Rotate bullet towards mouse position
            float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(fireDir * Speed, ForceMode2D.Impulse);

            controls.AttackDelay(Delay);

        }

    }


    



}
