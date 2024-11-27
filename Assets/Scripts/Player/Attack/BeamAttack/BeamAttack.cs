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

        if (!PlayerStat.Shopping && movement.canMove && PlayerStat.Mana>0 && (pInput.actions["SecondFire"].WasPressedThisFrame() || pInput.actions["3Fire"].WasPressedThisFrame() || pInput.actions["4Fire"].WasPressedThisFrame()))
        {
            bAttack = Instantiate(beamAttack, FirePoint.position, Quaternion.identity);
 


        }
        else if (PlayerStat.Mana<0  || pInput.actions["SecondFire"].WasReleasedThisFrame() || pInput.actions["3Fire"].WasReleasedThisFrame() || pInput.actions["4Fire"].WasReleasedThisFrame()) 
        {

            Destroy(bAttack);
        }

    }



}
