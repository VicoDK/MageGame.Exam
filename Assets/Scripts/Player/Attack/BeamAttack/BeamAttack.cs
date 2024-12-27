using UnityEngine;
using UnityEngine.InputSystem;

public class BeamAttack : MonoBehaviour
{

    PlayerStats PlayerStat;
    Movment movement;
    Transform FirePoint;
    public GameObject beamAttack;
    GameObject bAttack;
    Controls controls;




    // Update is called once per frame
    public void Fire()
    {
        if (PlayerStat == null || movement == null ||  FirePoint == null ||controls == null)
        {
            PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
            movement = GameObject.Find("PlayerBody").GetComponent<Movment>();
            FirePoint = GameObject.Find("PlayerFirePoint").GetComponent<Transform>();
            controls = GameObject.Find("PlayerBody").GetComponent<Controls>();

        }

        if (!PlayerStat.Shopping && movement.canMove && PlayerStat.Mana>0 && (Controls.PInput.actions["SecondFire"].WasPressedThisFrame() || Controls.PInput.actions["3Fire"].WasPressedThisFrame() || Controls.PInput.actions["4Fire"].WasPressedThisFrame()))
        {
            bAttack = Instantiate(beamAttack, FirePoint.position, Quaternion.identity);
 


        }
        else if (PlayerStat.Mana<0  || Controls.PInput.actions["SecondFire"].WasReleasedThisFrame() || Controls.PInput.actions["3Fire"].WasReleasedThisFrame() || Controls.PInput.actions["4Fire"].WasReleasedThisFrame()) 
        {

            Destroy(bAttack);
        }

    }



}
