using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Movment : MonoBehaviour
{
    [Header("Player Controlls")]
    //this is the input maneger

    public InputAction PlayerMovment;
    Vector2 MoveDir = Vector2.zero;

    //player speed
    public float speed;
    public float RollSpeed;

    //rigibody
    [SerializeField] private Rigidbody2D rb;
    
    //animation
    //public Animator Animator;

    
    PlayerStats PlayerStat;

    private void Start()
    {
        PlayerStat = GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        PlayerMovment.Enable();
    }

    private void OnDisable()
    {
        PlayerMovment.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //read player input
        MoveDir = PlayerMovment.ReadValue<Vector2>();

        if (Input.GetButton("Roll"))
        {
            rb.AddForce(MoveDir * RollSpeed);
            Debug.Log("Roll");
        }

        if (!PlayerStat.Shopping) 
        {
            //move player
            rb.velocity = new Vector2(MoveDir.x * speed * Time.deltaTime, MoveDir.y * speed * Time.deltaTime);
        }

    }

}
