using UnityEngine;

public class ToolInventory : MonoBehaviour
{
    public GameObject staffSlot;
    public GameObject cloakSlot;

    public GameObject[] Tools;

    void Update()
    {
        if (staffSlot != null)
        {
            if (staffSlot.gameObject.GetComponent<itemUse>().itemType != itemUse.whatItem.Staff)
            {
                GetTool(staffSlot);
                staffSlot = null;
            }

        }

        if (cloakSlot != null)
        {
            if (cloakSlot.gameObject.GetComponent<itemUse>().itemType != itemUse.whatItem.Cloak)
            {
                GetTool(cloakSlot);
                cloakSlot = null;
            }
        }
    }

    public static void GetTool(GameObject item)
    {
        Transform PlayerPOS = GameObject.Find("PlayerBody").GetComponent<Transform>();
        Movment PlayerMovement = GameObject.Find("PlayerBody").GetComponent<Movment>();
        ToolInventory inventory = GameObject.Find("InventoryManager").GetComponent<ToolInventory>();;
        bool itemAdded = false;

        while (!itemAdded)
        {
            for (int i = 0; i < inventory.Tools.Length+1; i++)
            {
                if (i < inventory.Tools.Length)
                {
                    if (inventory.Tools[i] == null)
                    {
                        itemAdded = true;
                        inventory.Tools[i] = item;
                        i = inventory.Tools.Length;
                    }
                }
                else 
                {
                    GameObject itemDrop = Instantiate(item, PlayerPOS.position, Quaternion.identity);
                    itemDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(PlayerMovement.LookDIR, 0) * 1, ForceMode2D.Impulse);
                    itemAdded = true;

                }
            }  
        }
    }
}
