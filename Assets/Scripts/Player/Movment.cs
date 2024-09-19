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

    //Roll
    public float RollSpeed;
    bool canRoll = true; 
    bool canMove = true; 
    float currentRollTime;
    float startRollTime = 0.3f;

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

        if (Input.GetButtonDown("Roll") && canRoll)
        {
            StartCoroutine(Dash(MoveDir));
            Debug.Log("Roll");
        }

        if (!PlayerStat.Shopping && canMove) 
        {
            //move player
            rb.velocity = new Vector2(MoveDir.x * speed * Time.deltaTime, MoveDir.y * speed * Time.deltaTime);
        }

    }


    IEnumerator Dash(Vector2 direction)
    {
        canRoll = false; // When Player Dash, Player Cannot Move
        canMove = false; // And Player Cannot Dash
      
        currentRollTime = startRollTime; // Reset the dash timer.

        while (currentRollTime > 0f)
        {
            currentRollTime -= Time.deltaTime; // Lower the dash timer each frame.

            direction.Normalize();
            rb.velocity = direction * RollSpeed; // Dash in the direction that was held down.
                                                 // No need to multiply by Time.DeltaTime here, physics are already consistent across different FPS.

            yield return null; // Returns out of the coroutine this frame so we don't hit an infinite loop.
        }

        rb.velocity = new Vector2(0f, 0f); // Stop dashing.

        canRoll = true;
        canMove = true; // CHANGE --- Need to enable movement after dashing.


    }

}
