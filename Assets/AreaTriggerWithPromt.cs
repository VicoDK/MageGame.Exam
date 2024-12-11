using UnityEngine;
using UnityEngine.InputSystem;

public class AreaTriggerWithPromt : MonoBehaviour
{
    
    //generald shop stuff
    [Header("Promt")]
    public GameObject dialog;
    public GameObject promt;
    private bool InRange;

    PlayerStats PlayerStats;
    private PlayerInput  pInput;
    Movment movement;

    void Start()
    {
        PlayerStats = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
        movement = GameObject.Find("PlayerBody").GetComponent<Movment>();
    }


    void OnTriggerEnter2D(Collider2D collision) //Something enters 
    {   
        if (collision.gameObject.CompareTag("Player")) // if player
        {   

            promt.SetActive(true); //activates shop promt
            InRange = true; //player ind range true


        }
        

    }

    void OnTriggerExit2D(Collider2D collision) //somthing exits
    {
        if (collision.gameObject.CompareTag("Player")) // if player
        {
            promt.SetActive(false); //deactivates shop promt
            InRange = false; //player ind range false

        }
    }

    void Update()
    {
        if (pInput.actions["Interact"].WasPressedThisFrame() && InRange && !PlayerStats.Shopping && movement.canMove) //if pressed Interact and in rang
        {   
            dialog.SetActive(true);
            


        }
    }
}
