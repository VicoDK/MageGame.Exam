using UnityEngine;
using UnityEngine.InputSystem;

public class BeamAttack : MonoBehaviour
{

    PlayerInput pInput;
    PlayerStats PlayerStat;
    Movment movement;
    Transform FirePoint;
    public GameObject beamAttack;
    GameObject bAttack;
    Controls controls;
    public float ManaCost;
    bool Attacking;

    // Update is called once per frame
    public void Fire()
    {
        if (PlayerStat == null || movement == null || pInput == null || FirePoint == null ||controls == null)
        {
            PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
            movement = GameObject.Find("PlayerBody").GetComponent<Movment>();
            pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
            FirePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
            controls = GameObject.Find("PlayerBody").GetComponent<Controls>();

        }

        if (pInput.actions["SecondFire"].WasPressedThisFrame() &&  !PlayerStat.Shopping && movement.canMove && PlayerStat.Mana>0|| pInput.actions["FireController"].WasPressedThisFrame() &&  !PlayerStat.Shopping && movement.canMove && PlayerStat.Mana>0)
        {
            bAttack = Instantiate(beamAttack, FirePoint.position, Quaternion.identity);
            bAttack.GetComponentInChildren<LightningAttack>().ManaCost = ManaCost;


        }
        else if (pInput.actions["SecondFire"].WasReleasedThisFrame() &&  !PlayerStat.Shopping && movement.canMove|| pInput.actions["FireController"].WasReleasedThisFrame() &&  !PlayerStat.Shopping && movement.canMove || PlayerStat.Mana <=0 ) 
        {

            Destroy(bAttack);
        }

    }


}
