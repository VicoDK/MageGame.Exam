using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    public float fireRate;
    private float fireTime;
    public float damage;

    
    Inventory inventory;

    public MagicTypes.Magictype magicType;
    PlayerStats playerStats;
    public float ManaCost;


    void Start ()
    {
        playerStats = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
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
        playerStats.Mana -= ManaCost * Time.deltaTime;
        playerStats.ManaCost();



    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the fireTime is less than 0 to allow for damage
        if (fireTime < 0)
        {
            // Define the size of the box (width and height)
            Vector2 boxSize = new Vector2(transform.localScale.x, transform.localScale.y); // Replace with your desired width and height

            // Get all colliders in the rectangular area
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f); // 0f for no rotation

            foreach (Collider2D enemy in hitEnemies)
            {
                // Check if the collider is an enemy
                if (enemy.GetComponent<EnemyHealth>() != null)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(damage, magicType);
                }
            }

            // Reset fireTime after damaging all enemies
            fireTime = fireRate;
        }
    }

}
