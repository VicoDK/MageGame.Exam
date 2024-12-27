using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ObjectEffect : MonoBehaviour
{

    public enum Type
    {
        none,
        Torch,
        Ice
    }
    public Type objectType;


    [Header("Torch")]
    public SpriteRenderer Fire;
    public bool Burning;

    [Header("Ice")]

    public SpriteRenderer ice;
    public Collider2D collide;
    bool frosen;
    public float frezeTime;
    float frezeTimeCount;



    public void ObjectEffects(float Damage, MagicTypes.Magictype magicType)
    {

        switch (objectType)
        {
            case Type.Torch:
            
            if (!Burning && magicType == MagicTypes.Magictype.FireMagic)
            {
                if (Fire != null)
                {
                    Fire.enabled = true;
                    Burning = true;
                }
            }
            else if (Burning && magicType == MagicTypes.Magictype.WaterMagic)
            {
                if (Fire != null)
                {
                    Fire.enabled = false;
                    Burning = false;

                }
            }
            break;
            case Type.Ice:

            if (!frosen && magicType == MagicTypes.Magictype.IceMagic)
            {
                if (ice != null)
                {
                    collide.isTrigger = true;
                    ice.enabled = true;
                    frosen = true;
                }

            }
            else if (frosen && magicType == MagicTypes.Magictype.FireMagic)
            {
                if(ice != null)
                {
                    collide.isTrigger = false;
                    ice.enabled = false;
                    frosen = false;
                }

            }


            break;


        }



    }

    void Start()
    {
        if (Burning)
        {
            if (Fire != null)
            {
                Fire.enabled = true;
            }
        }
        else 
        {
            if (Fire != null)
            {
                Fire.enabled = false;
            }
        }

    }

}
