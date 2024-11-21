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
    int timer = 0;

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
        else if (!BurningEffect && !FrozenEffect && !WetEffect)
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

            }
            else if (enemyMagicType == MagicTypes.Magictype.plantMagic)
            {
                //Strong Attacks
            }
            else 
            {
                //Neutral Attack
            }  

            break;
            case MagicTypes.Magictype.IceMagic : //IceMagic
            
            if (enemyMagicType == MagicTypes.Magictype.FireMagic )
            {
                //weak attacks

            }
            else if (enemyMagicType == MagicTypes.Magictype.plantMagic )
            {
                //Strong Attacks
            }            
            else 
            {
                //Neutral Attack
            }  

            break;
            case MagicTypes.Magictype.LightingMagic : //LightingMagic

            if (enemyMagicType == MagicTypes.Magictype.RockMagic )
            {
                //weak attacks

            }
            else if (enemyMagicType == MagicTypes.Magictype.WaterMagic )
            {
                //Strong Attacks
            }   
            else 
            {
                //Neutral Attack
            }  

            break;
            case MagicTypes.Magictype.WindMagic : //WindMagic

            if (1 == 2)
            {
                //weak attacks                                                                DONT USE

            }
            else if (enemyMagicType == MagicTypes.Magictype.RockMagic )
            {
                //Strong Attacks
            }   
            else 
            {
                //Neutral Attack
            }  

            break;
            case MagicTypes.Magictype.plantMagic : //plantMagic

            if (enemyMagicType == MagicTypes.Magictype.FireMagic )
            {
                //weak attacks

            }
            else if (1 == 2)
            {
                //Strong Attacks                                                                DONT USE
            }   
            else 
            {
                //Neutral Attack
            }  

            break;
            case MagicTypes.Magictype.RockMagic : //RockMagic

            if (enemyMagicType == MagicTypes.Magictype.WaterMagic )
            {
                //weak attacks

            }
            else if (enemyMagicType == MagicTypes.Magictype.LightingMagic ||  enemyMagicType == MagicTypes.Magictype.FireMagic)
            {
                //Strong Attacks
            }   
            else 
            {
                //Neutral Attack
            }  

            break;
            case MagicTypes.Magictype.WaterMagic : //WaterMagic

            if (1 == 2)
            {
                //weak attacks                                                                 DONT USE

            }
            else if (enemyMagicType == MagicTypes.Magictype.FireMagic  || enemyMagicType == MagicTypes.Magictype.RockMagic)
            {
                //Strong Attacks
            }
            else 
            {
                //Neutral Attack
            }                 

            break;
            case MagicTypes.Magictype.EnergyMagic : //EnergyMagic

            if (enemyMagicType == MagicTypes.Magictype.WaterMagic )
            {
                //weak attacks

            }
            else if (enemyMagicType == MagicTypes.Magictype.WaterMagic )
            {
                //Strong Attacks
            }
            else 
            {
                //Neutral Attack
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
    public void Bruning(int Burntime)
    {
        
        //if enemy is not wet or forzen 
        if (!WetEffect && !FrozenEffect)
        {
            //enemy is burning 
            BurningEffect = true;
            if (timer == 0)
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
            //if they were wet or frozen, now they are dry
            WetEffect = false;
            FrozenEffect = false;
        }
        
    }

    IEnumerator BurningDamage(int Burntime)
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
            Debug.Log(timer);


        }

        if (timer == 0)
        {
            BurningEffect = false;
            Debug.Log("stop burn");
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


