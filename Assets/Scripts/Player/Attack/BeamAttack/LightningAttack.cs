using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    public float fireRate;
    private float fireTime;
    public float damage;

    
    Inventory inventory;

    public MagicTypes.Magictype magicType;



    void Start ()
    {

        inventory = GameObject.Find("GameManager").GetComponentInChildren<Inventory>();
        if (inventory.staffSlot != null)
        {
            if (inventory.staffSlot.GetComponent<itemUse>().damageModifer != 0)
            {
                if (inventory.staffSlot.GetComponent<itemUse>().magicAffinity == magicType)
                {
                    damage *= inventory.staffSlot.GetComponent<itemUse>().damageModifer * inventory.staffSlot.GetComponent<itemUse>().magicAffinityModifier;
                }
                else
                {
                    damage *= inventory.staffSlot.GetComponent<itemUse>().damageModifer;
                }
            }
        }
    }

    void Update ()
    {
        fireTime =- Time.deltaTime;



    }

    void  OnTriggerStay2D(Collider2D collision)
    {
        if (fireTime <0 && collision.GetComponent<EnemyHealth>() != null) 
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage, magicType);
            fireTime = fireRate;
        }

    }

}
