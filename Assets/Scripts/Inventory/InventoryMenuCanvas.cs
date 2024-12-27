using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryMenuCanvas : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject spellList;
    private bool Aktive;


    PlayerStats PlayerStat;
    Movment movement;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
        movement = GameObject.Find("PlayerBody").GetComponent<Movment>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controls.PInput.actions["Inventory"].WasPressedThisFrame() && !Aktive && PlayerStat.Alive)
        {
            InventoryMenu.SetActive(true);
            Aktive = true;
            Time.timeScale = 0;
            movement.canMove = false;


        }
        else if (Controls.PInput.actions["Inventory"].WasPressedThisFrame() && Aktive && PlayerStat.Alive)
        {
            InventoryMenu.SetActive(false);
            spellList.SetActive(false);
            Aktive = false;
            Time.timeScale = 1;
            movement.canMove = true;


        }
        
    }

    public void LeaveInv()
    {
        InventoryMenu.SetActive(false);
        Aktive = false;
        Time.timeScale = 1;
        movement.canMove = true;
    }

}
