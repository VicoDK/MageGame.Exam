using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class EnemyHealth : MonoBehaviour
{
    [Header("Stats")]
    
    //health
    public float Health = 100;

    private float MaxHealth;

    //Generald
    private Rigidbody2D rb;

    [Header("Effect Damage + Effect Timer")]

    //effects
    private bool BurningEffect;
    public bool FrozenEffect;
    public bool WetEffect;

    [Header("Effect Multiplier")]

    [Header("Burning Effect")]
    public float BurnDamage;
    public float BurnTimer;
    public int BurnEffectLength;
    private float Burntimestamp1;
    private int BurnTicks;

    public Image HealthBar;
    public bool Alive = true;
    public GameObject Ice;
    public MagicTypes.Magictype enemyMagicType;

    MagicTypes magicTypes;
    float timer = 0;

    void Start()
    {

        //Componets
        magicTypes = GameObject.Find("MagicManager").GetComponent<MagicTypes>();
        rb = GetComponent<Rigidbody2D>();

        //Other
        MaxHealth = Health;
    }

    void FixedUpdate()
    {

        HealthBar.fillAmount = Health / MaxHealth; // healthbar
        
        //check if enemy is dead
        if (Health <= 0)
        {
            Alive = false;
            Destroy(gameObject);
        }


    }

    void Update()
    {
        //here we see what effect we should do
        if (BurningEffect)
        {
            //turn player red
            GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 125); 
        }
        else if (WetEffect)
        {
            //make them change color to wet
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 255, 125); 
        }
        else if (!BurningEffect && !WetEffect)
        {
            //make them change color to normal
            GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255); 
        }


    }

    public void TakeDamage(float Damage, MagicTypes.Magictype magicType)
    {   
        switch (magicType)
        {
            case MagicTypes.Magictype.FireMagic : //FireMagic

            if (enemyMagicType == MagicTypes.Magictype.WaterMagic || enemyMagicType == MagicTypes.Magictype.RockMagic)
            {
                //weak attacks
                Health -= Damage * magicTypes.damageDisadvanced;

            }
            else if (enemyMagicType == MagicTypes.Magictype.plantMagic)
            {
                //Strong Attacks
                Health -= Damage * magicTypes.damageAdvanced;
            }
            else 
            {
                //Neutral Attack
                Health -= Damage;
            }  

            if (WetEffect)
            {
                WetEffect = false;
            }
            

            break;
            case MagicTypes.Magictype.IceMagic : //IceMagic
            
            if (enemyMagicType == MagicTypes.Magictype.FireMagic )
            {
                //weak attacks
                Health -= Damage * magicTypes.damageDisadvanced;

            }
            else if (enemyMagicType == MagicTypes.Magictype.plantMagic )
            {
                //Strong Attacks
                Health -= Damage * magicTypes.damageAdvanced;
            }            
            else 
            {
                //Neutral Attack
                Health -= Damage;
            }  

            break;
            case MagicTypes.Magictype.LightingMagic : //LightingMagic

            if (enemyMagicType == MagicTypes.Magictype.RockMagic )
            {
                //weak attacks
                Health -= Damage * magicTypes.damageDisadvanced;

            }
            else if (enemyMagicType == MagicTypes.Magictype.WaterMagic )
            {
                //Strong Attacks
                Health -= Damage * magicTypes.damageAdvanced;
            }   
            else 
            {
                //Neutral Attack
                Health -= Damage;
            }  

            if (WetEffect)
            {
                Health -= Damage * (magicTypes.LightingOnWetEnemyModifier-1);
            }

            break;
            case MagicTypes.Magictype.WindMagic : //WindMagic

            if (1 == 2)
            {
                //weak attacks                                                                DONT USE
                //Health -= Damage * magicTypes.damageDisadvanced;

            }
            else if (enemyMagicType == MagicTypes.Magictype.RockMagic )
            {
                //Strong Attacks
                Health -= Damage * magicTypes.damageAdvanced;
            }   
            else 
            {
                //Neutral Attack
                Health -= Damage;
            }  

            break;
            case MagicTypes.Magictype.plantMagic : //plantMagic

            if (enemyMagicType == MagicTypes.Magictype.FireMagic )
            {
                //weak attacks
                Health -= Damage * magicTypes.damageDisadvanced;

            }
            else if (1 == 2)
            {
                //Strong Attacks                                                                DONT USE
                //Health -= Damage * magicTypes.damageAdvanced;
            }   
            else 
            {
                //Neutral Attack
                Health -= Damage;
            }  

            break;
            case MagicTypes.Magictype.RockMagic : //RockMagic

            if (enemyMagicType == MagicTypes.Magictype.WaterMagic )
            {
                //weak attacks
                Health -= Damage * magicTypes.damageDisadvanced;

            }
            else if (enemyMagicType == MagicTypes.Magictype.LightingMagic ||  enemyMagicType == MagicTypes.Magictype.FireMagic)
            {
                //Strong Attacks
                Health -= Damage * magicTypes.damageAdvanced;
            }   
            else 
            {
                //Neutral Attack
                Health -= Damage;
            }  

            break;
            case MagicTypes.Magictype.WaterMagic : //WaterMagic

            if (1 == 2)
            {
                //weak attacks                                                                 DONT USE
                //Health -= Damage * magicTypes.damageDisadvanced;

            }
            else if (enemyMagicType == MagicTypes.Magictype.FireMagic  || enemyMagicType == MagicTypes.Magictype.RockMagic)
            {
                //Strong Attacks
                Health -= Damage * magicTypes.damageAdvanced;
            }
            else 
            {
                //Neutral Attack
                Health -= Damage;
            }                 

            break;
            case MagicTypes.Magictype.EnergyMagic : //EnergyMagic

            if (enemyMagicType == MagicTypes.Magictype.WaterMagic )
            {
                //weak attacks
                Health -= Damage * magicTypes.damageDisadvanced;

            }
            else if (enemyMagicType == MagicTypes.Magictype.WaterMagic )
            {
                //Strong Attacks
                Health -= Damage * magicTypes.damageAdvanced;
            }
            else 
            {
                //Neutral Attack
                Health -= Damage;
            }  

            break;
        }
 

    } 
    #region Effects
    #region Freze
    //function to frezze the enemy
    public void Frozen(float FreezeTime)
    {
        if (enemyMagicType != MagicTypes.Magictype.FireMagic)
        {
            //enemy is frozen  (but not wet)  (but not burning)
            FrozenEffect = true;
            WetEffect = false;
            BurningEffect = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Ice.SetActive(true);
            BurningEffect = false;
            timer = 0;
            Invoke("UnFreze", FreezeTime);
        }

    }

    public void UnFreze()
    {
        if (enemyMagicType != MagicTypes.Magictype.FireMagic)
        {
            Ice.SetActive(false); // removes ice 
            rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation; 
            FrozenEffect = false;
        }        

    }
    #endregion Freze
    #region Burning
    //function for burning enemy
    public void Bruning(float Burntime)
    {
        
        //if enemy is not wet or forzen 
        if (!WetEffect && !FrozenEffect && enemyMagicType != MagicTypes.Magictype.WaterMagic)
        {
            //enemy is burning 
            BurningEffect = true;
            if (timer == 0 )
            {
                
                StartCoroutine(BurningDamage(Burntime));
            }
            else  if (Burntime > timer)
            {
                timer = Burntime;   
            }
  
        }
        else
        {
            UnFreze();
            CancelInvoke("UnFreze");
            //if they were wet or frozen, now they are dry
            WetEffect = false;
            FrozenEffect = false;
        }
        
    }

    IEnumerator BurningDamage(float Burntime)
    {

        timer = Burntime;


        while (timer > 0)
        {

            Health -= magicTypes.BurnDamagePerSekund/3;
            yield return new WaitForSeconds(0.3f);
            Health -= magicTypes.BurnDamagePerSekund/3;
            yield return new WaitForSeconds(0.3f);
            Health -= magicTypes.BurnDamagePerSekund/3;
            yield return new WaitForSeconds(0.3f);
            timer--;

        }

        if (timer == 0)
        {
            BurningEffect = false;
        }
        
    
    }


    #endregion Burning
    #region Wet

    //function for making the enemy wet
    public void Wet()
    {
        
        //if enemy is not burning or forzen 
        if (!BurningEffect && !FrozenEffect)
        {
            //make them wet
            WetEffect = true;
        }
        else if (BurningEffect) //if burning dry them
        {
            BurningEffect = false;

        }

    }

    #endregion Wet 
    #endregion Effects

}