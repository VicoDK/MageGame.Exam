using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalEnemyAttack : MonoBehaviour
{
    [Header("Enemy attack")]
    public float AttackDamage;
    public float AttackSpeed;
    private bool AttackReady = true;

    //check if colision
    public void OnTriggerStay2D(Collider2D collision)
    {

        //check if its the player and attack is ready
        if(collision.gameObject.CompareTag("Player") && AttackReady)
        {
            //do damage
            collision.GetComponent<PlayerStats>().TakeDamage(AttackDamage);
            //start timer
            StartCoroutine(Attacks());
        }

        
    }

    //Attack timer
    private IEnumerator Attacks ()
    {
        //here we set attack ready to false so we can't attack again
        AttackReady = false;
        //here we wait some seconds
        yield return new WaitForSeconds(AttackSpeed);
        //here we set attack ready to true so we can attack again
        AttackReady = true;
        
    }


}
