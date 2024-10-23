using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [Header("Player Input System")]
    //add new input system
    private PlayerInput  pInput;
    [Header("Fire Point")]
    public Transform FirePoint;


    [Header("Meleattack")]
    public GameObject Sword;

    [Header("Basic attack")]
    public float Speed;
    public GameObject BaseAttack;
    public float Delay = 0.2f; //Static
    public bool AttackReady = true; //static
    PlayerStats PlayerStat;

    private void Start()
    {
        PlayerStat = GetComponent<PlayerStats>();
        pInput = GetComponent<PlayerInput>();
    }
    



    void Update()
    {
        //base attack
        //here we check after input and if attack is ready
        if (pInput.actions["Fire"].WasPressedThisFrame() && AttackReady && !PlayerStat.Shopping)
        {

            //all the code made from line 19 to 45 is made by ChatGBT (with some small changes) with this promt "make a script for unity2d, where the players mouse is fire a object there"
            // Get mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calculate direction towards mouse position
            Vector2 fireDir = (mousePosition - FirePoint.position).normalized;

            // Instantiate bullet at fire point
            GameObject bullet = Instantiate(BaseAttack, FirePoint.position, Quaternion.identity);

            // Rotate bullet towards mouse position
            float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(fireDir * Speed, ForceMode2D.Impulse);

            //here we start a IEnumerator for the timer
            StartCoroutine(AttackDelay());

        }

    }

    //this is the IEnumerator for timer
    public IEnumerator AttackDelay ()
    {
        //attack is not ready to go now
        AttackReady = false;
        //here we wait some time
        yield return new WaitForSeconds(Delay);
        //now attack is ready
        AttackReady = true;
          
    }

    



}
