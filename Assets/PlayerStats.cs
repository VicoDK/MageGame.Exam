using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    [Header("Health")]
    public bool Alive;
    public float _Health;
    public static float Health;
    private float MaxHealth;
    public float _HealthRegn;
    public static float HealthRegn;

    [Header("Mana")]
    public float _Mana;
    public static float Mana;
    private float MaxMana;
    public float _ManaRegn;
    public static float ManaRegn;

    void Start()
    {
        Health = _Health;
        HealthRegn = _HealthRegn;
        MaxHealth = _Health;
        Mana = _Mana;
        MaxMana = _Mana;
        ManaRegn = _ManaRegn;
    }   

    void FixedUpdate()
    {
        _Health = Health;
        _HealthRegn = HealthRegn;
        _Mana = Mana;
        _ManaRegn = ManaRegn;


        if (MaxMana > Mana && Alive)
        {
            Mana += ManaRegn;
        }


        if (Health < 0 || Health == 0)
        {
            Alive = false;
        }
        else if (MaxHealth > Health)
        {
            Health += HealthRegn;
        }

    }

    //function for taking damage
    public void TakeDamage(float Damage)
    {

        Health -= Damage;
        

    } 

}
