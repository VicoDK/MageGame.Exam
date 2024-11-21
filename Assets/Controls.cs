using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    public bool AttackReady;
    PlayerInput pInput;
    SpellInventory spellInventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackReady = true;
        pInput = GetComponent<PlayerInput>();
        spellInventory = GameObject.Find("Inventory").GetComponent<SpellInventory>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pInput.actions["Fire"].WasPressedThisFrame()) //Mouse input
        {
            spellInventory.BasicAttack.GetComponent<Attack>().Fire();
        }

        if (pInput.actions["SecondFire"].WasPressedThisFrame()) //part1
        {
            if (spellInventory.spellsEuipe[0].CompareTag("BallAttack"))
            {
                spellInventory.spellsEuipe[0].GetComponent<BallAttack>().Fire();
            }
            else if (spellInventory.spellsEuipe[0].CompareTag("BeamAttack"))
            {
                spellInventory.spellsEuipe[0].GetComponent<BeamAttack>().Fire();
            }
        }
        else if (pInput.actions["SecondFire"].WasReleasedThisFrame()) 
        {
            if (spellInventory.spellsEuipe[0].CompareTag("BeamAttack"))
            {
                spellInventory.spellsEuipe[0].GetComponent<BeamAttack>().Fire();
            }

        }
        if (pInput.actions["3Fire"].WasPressedThisFrame()) //Part2
        {
            if (spellInventory.spellsEuipe[1].CompareTag("BallAttack"))
            {
                spellInventory.spellsEuipe[1].GetComponent<BallAttack>().Fire();
            }
            else if (spellInventory.spellsEuipe[1].CompareTag("BeamAttack"))
            {
                spellInventory.spellsEuipe[1].GetComponent<BeamAttack>().Fire();
            }
        }
        else if (pInput.actions["3Fire"].WasReleasedThisFrame()) 
        {
            if (spellInventory.spellsEuipe[1].CompareTag("BeamAttack"))
            {
                spellInventory.spellsEuipe[1].GetComponent<BeamAttack>().Fire();
            }

        }
        if (pInput.actions["4Fire"].WasPressedThisFrame()) //Part3
        {
            if (spellInventory.spellsEuipe[2].CompareTag("BallAttack"))
            {
                spellInventory.spellsEuipe[2].GetComponent<BallAttack>().Fire();
            }
            else if (spellInventory.spellsEuipe[2].CompareTag("BeamAttack"))
            {
                spellInventory.spellsEuipe[2].GetComponent<BeamAttack>().Fire();
            }
        }
        else if (pInput.actions["4Fire"].WasReleasedThisFrame()) 
        {
            if (spellInventory.spellsEuipe[2].CompareTag("BeamAttack"))
            {
                spellInventory.spellsEuipe[2].GetComponent<BeamAttack>().Fire();
            }

        }
    
    }


    public void AttackDelay(float delay)
    {
        AttackReady = false;

        //here we start a IEnumerator for the timer
        Invoke("AttackDelayPart2", delay);
    }

    void AttackDelayPart2()
    {
        
        //now attack is ready
        AttackReady = true;
    }


}
