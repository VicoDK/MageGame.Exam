using UnityEngine;
using UnityEngine.InputSystem;

public class BeamAttack : MonoBehaviour
{

    PlayerInput pInput;
    PlayerStats PlayerStat;
    Movment movement;
    public Transform FirePoint;
    public GameObject beamAttack;
    GameObject bAttack;
    public float ManaCost;
    bool Attacking;

    void Start()
    {
        PlayerStat = GetComponent<PlayerStats>();
        movement = GetComponent<Movment>();
        pInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pInput.actions["SecondFire"].WasPressedThisFrame() &&  !PlayerStat.Shopping && movement.canMove && PlayerStat.Mana>0|| pInput.actions["FireController"].WasPressedThisFrame() &&  !PlayerStat.Shopping && movement.canMove && PlayerStat.Mana>0)
        {
            bAttack = Instantiate(beamAttack, FirePoint.position, Quaternion.identity);
            PlayerStat.ManaCost();
            Attacking = true;

        }
        else if (pInput.actions["SecondFire"].WasReleasedThisFrame() &&  !PlayerStat.Shopping && movement.canMove|| pInput.actions["FireController"].WasReleasedThisFrame() &&  !PlayerStat.Shopping && movement.canMove || PlayerStat.Mana <=0 ) 
        {
            Attacking = false;
            Destroy(bAttack);
        }

    }

    void FixedUpdate()
    {
        if (Attacking)
        {
            PlayerStat.Mana -= ManaCost;
        }

    }

}
