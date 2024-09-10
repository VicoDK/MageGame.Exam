// kilde : https://www.youtube.com/watch?app=desktop&v=TOPj3uHZgQk

//add this to a capsule, add a Rigidbody, capsule collider, add camera as child objekt to player, Add playerLook to Player and Character Controller
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class movment : MonoBehaviour
{
    //Denne variable bliver brugt til at danne mere glate bevægelser
    public float MoveSmoothTime;
    // denne bestemmer hvor stærk tyndekraften skulle være på spilleren.
    public float GravityStrength;
    // variablen der står for hvor højt spilleren kan hoppe.
    public float JumpStrength;
    // variablen for hvor hurtig spilleren kan gå
    public float WalkSpeed;
    // variablen for hvor hurtig spilleren kan løbe
    public float RunSpeed;

    // denne variablen bruger vi til at hente en CharacterController som vi har tilføjet til spilleren
    private CharacterController Controller;

    // det 2 variabler under bliver brugt til at smothe spilleren bevægelserne ud
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    // denne variablen bliver brugt når spilleren bliver påvirket af tyde kraft
    private Vector3 currentForceVelocity;

    //dette er noget af den kode jeg selv har skrevet
    // hen henter vi en prefab med et script på
    public GameObject Sphere;


    
    // spawne sphere 
    // køre når scenen starter
    void Start()
    {
        //her henter vi CharacterController og tildeler den en variable
        Controller = GetComponent<CharacterController>();
    }

    // Spilleren bevøgelse
    // køre hvert frame
    void Update()
    {
        // mere af min ejen kode
        // her tjekker vi om knappen E bliver trykket og hvis den gør så køres hvad der er inde på if statmentet
        if (Input.GetKeyDown(KeyCode.E))
        {
            // her skaber vi hvor Prefab fra tidliger og giver den locationen af det objekt scriptet er tilknytte, i denne situration er det spilleren.
            Instantiate(Sphere, this.transform);
        }

        // her laver vi en Vector3 som hedder PlayerInput og tildeler den en ny vector3
        Vector3 PlayerInput = new Vector3
        {
            // denne vector3 tildeler dens værdier ud fra om Horizontal/Vertical akserne bliver trykket (Horizontal = a og d eller venstre og højre pillene, Vertical = w og s eller up og ned pillene)
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };

        // her tjekker vi om PlayerInput vector3 har en længde på over 1 og hvis ja så køres if statmentet
        if(PlayerInput.magnitude >1f)
        {
            // her gør vi så PlayerInput vector3 er 1 lang men med samme vinkel
            PlayerInput.Normalize();

        }

        //her finder vi hvad vej spilleren kigger og tildeler den værdi til en vector3 ved navn MoveVector
        Vector3 MoveVector = transform.TransformDirection(PlayerInput);

        // her skabes en nu variable ved navn currentSpeed som er en float og tildeler den outputet fra en Ternary operation, 
        // hvor vi tjekker om venstre shift er trykket, hvis ja så får den værdien RunSpeed og hvis ikke får den WalkSpeed
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;

        // her bruger vi Vector3.SmoothDamp funktionen på vores CurrentMoveVelocity
        CurrentMoveVelocity = Vector3.SmoothDamp(

            // i denne vecotor3 ved navn CurrentMoveVelocity er der 4 parametere
            //1 CurrentMoveVelocity er farten på spilleren
            CurrentMoveVelocity,
            //2 hastigheden som spillere kan have max kan havde
            MoveVector * currentSpeed,
            //3 MoveDampVelocity er variblen for hvor meget spilleren hastighed skal glat gøres
            // ref betyder at det er denne varible der bliver ændret og ikke bare ind sat
            ref MoveDampVelocity,
            //4 tiden det tager for at ramme top speed
            MoveSmoothTime
        );

        //her tager vi move funktionen i karrakter controlleren og giver den værdien af CurrentMoveVelocity * Time.deltaTime
        // Time.deltaTime er her så farten ikke bliver baseret på frames en computer kan havde men tid.
        Controller.Move(CurrentMoveVelocity * Time.deltaTime);


        //spileren hop
        // laver vi en Ray som vi kalder GroundCheckRay, denne ray tager 2 input spilleren position og laver en Vector3 der går ned
        Ray GroundCheckRay = new Ray(transform.position, Vector3.down);
        // her tjekker vi om der er noget mellem GroundCheckRay (spilleren) og 1.1f ned
        // hvis der er et objekt giver den svartet true
        if(Physics.Raycast(GroundCheckRay, 1.1f))
        {   
            // her sætter vi currentForceVelocity.y til -2f, så når spileren gå op af en bakke at de ikke begynder at flyve
            currentForceVelocity.y = -2f;

            //hvis Space er trykket så køre if statmentet
            if(Input.GetKey(KeyCode.Space))
            {
                // her sætter vi currentForceVelocity.y = JumpStrength og det gør så spilleren kommer op af
                currentForceVelocity.y = JumpStrength;
            }

        }
        else
        {
            // hvis spilleren er i luften
            //tager vi og minuser currentForceVelocity.y med GravityStrength*Time.deltaTime så jo længere den er i luften jo hurtiger falder den.
            currentForceVelocity.y -=GravityStrength*Time.deltaTime;
        }
        //her gør vi som på linje 99 bare med y aksen.
        Controller.Move(currentForceVelocity * Time.deltaTime);
    }
}
