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

        if (pInput.actions["SecondFire"].WasPressedThisFrame()) //Mouse input
        {
            if (spellInventory.spellsEuipe[0].CompareTag("BallAttack"))
            {
                spellInventory.spellsEuipe[0].GetComponent<BallAttack>().Fire();
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
