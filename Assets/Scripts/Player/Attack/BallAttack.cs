using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallAttack : MonoBehaviour
{
    [Header("General stats")]
    private PlayerInput  pInput;
    public Transform FirePoint;
    public float Speed;
    public int ManaCost;
    private GameObject bullet;


    [Header("Ball Attack")]
    public GameObject Ball;


    PlayerStats PlayerStat;
    Attack attack;
    public Vector3 mousePosition;

    private void Start()
    {
        PlayerStat = GetComponent<PlayerStats>();
        attack = GetComponent<Attack>();
        pInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //ball attacks
        //rigistere input
        if (pInput.actions["SecondFire"].WasPressedThisFrame() && PlayerStat.Mana >= ManaCost && attack.AttackReady && !PlayerStat.Shopping)
        {
            //all the code made from line 19 to 45 is made by ChatGBT (with some small changes) with this promt "make a script for unity2d, where the players mouse is fire a object there"
            // Get mouse position
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calculate direction towards mouse position
            Vector2 fireDir = (mousePosition - FirePoint.position).normalized;

            // Instantiate bullet at fire point
            bullet = Instantiate(Ball, FirePoint.position, Quaternion.identity);

            // Rotate bullet towards mouse position
            float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(fireDir * Speed, ForceMode2D.Impulse);

            //mana cost
            PlayerStat.Mana -= ManaCost;
            PlayerStat.ManaCost(); // this function makes sure that the manaRegen works

            StartCoroutine(attack.AttackDelay());

        }
    }

}
