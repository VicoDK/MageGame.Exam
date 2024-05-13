using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{
    //this is the input maneger
    public InputAction PlayerMovment;
    Vector2 MoveDir = Vector2.zero;

    //player speed
    private float speed = 5f;

    //rigibody
    [SerializeField] private Rigidbody2D rb;
    
    //animation
    //public Animator Animator;

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
        //Animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); 
        //Animator.SetFloat("Speed2", Mathf.Abs(rb.velocity.y));        

    }

    void FixedUpdate()
    {
        //move player
        rb.velocity = new Vector2(MoveDir.x * speed, MoveDir.y * speed);
    }
}
