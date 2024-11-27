using System.Collections.Generic;
using UnityEngine;

public class BeamAttacksSpell : MonoBehaviour
{
    public float fireRate;
    private float fireTime;
    public float damage;
    public float pushForce;
    public Transform Center;
    public Transform Beam;

    
    Inventory inventory;

    public MagicTypes.Magictype magicType;
    PlayerStats playerStats;
    public float ManaCost;
    Vector2 boxSize; 
    List<GameObject> hitEnemies = new List<GameObject>();
    
    public MagicTypes.magicEffects magicEffect;
    public float EffectTime;


    void Start ()
    {
        boxSize = new Vector2(transform.localScale.x, transform.localScale.y); 
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

    void FixedUpdate ()
    {
        fireTime =- Time.deltaTime;
        playerStats.Mana -= ManaCost * Time.deltaTime;
        playerStats.ManaCost();

        if (playerStats.Mana < 0)
        {
            Destroy(gameObject);
        }


        if (fireTime < 0)
        {

            foreach (GameObject enemy in hitEnemies)
            {
                // Check if the collider is an enemy
                if (enemy.GetComponent<EnemyHealth>() != null)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(damage, magicType);
                }

                if(pushForce > 0 && enemy.CompareTag("Enemy"))
                {
                    Vector3 fireDir = (enemy.transform.position - Center.position).normalized;
                    enemy.GetComponent<Rigidbody2D>().AddForce(fireDir*pushForce);
                }


                if (enemy.GetComponent<EnemyHealth>() != null)
                {
                    //here we check which effect to give
                    if(magicEffect == MagicTypes.magicEffects.BurningEffect)
                    {
                        enemy.GetComponent<EnemyHealth>().Bruning(EffectTime);
                    }
                    else if(magicEffect == MagicTypes.magicEffects.FrozenEffect)
                    {
                        enemy.GetComponent<EnemyHealth>().Frozen(EffectTime);
                    }
                    else if(magicEffect == MagicTypes.magicEffects.WetEffect)
                    {
                        enemy.GetComponent<EnemyHealth>().Wet();
                    }

                }
            }
                fireTime = fireRate;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        hitEnemies.Add(collision.gameObject);

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        hitEnemies.Remove(collision.gameObject);

    }

}