using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Movment : MonoBehaviour
{
    [Header("Player Controlls")]
    //this is the input maneger

    //public InputAction PlayerMovment;
    private PlayerInput  pInput;
    public Vector2 MoveDir = Vector2.zero;

    //player speed
    public float speed;

    //Roll
    public bool canMove = true; 
    public int LookDIR;

    //rigibody
    [SerializeField] private Rigidbody2D rb;
    
    //animation
    //public Animator Animator;

    
    PlayerStats PlayerStat;

    private void Start()
    {
        PlayerStat = GetComponent<PlayerStats>();
        pInput = GetComponent<PlayerInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //read player input
        MoveDir = pInput.actions.FindAction("Move").ReadValue<Vector2>();

        Flip();
      

    }

    void FixedUpdate()
    {
        if (!PlayerStat.Shopping && canMove) 
        {
            //gameObject.transform.Translate(MoveDir.x * speed , MoveDir.y * speed ,0 );
            rb.linearVelocity = new Vector3(MoveDir.x * speed , MoveDir.y * speed, 0).normalized * speed;
        }
    }



    void Flip()
    {

        if (MoveDir.x < 0 && canMove && !PlayerStat.Shopping)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
            LookDIR = -1;
        }
        else if (MoveDir.x > 0 && canMove && !PlayerStat.Shopping)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
            LookDIR = 1;
            
        }

    }

}
