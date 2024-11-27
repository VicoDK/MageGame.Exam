using UnityEngine;

public class MagicTypes : MonoBehaviour
{
    //generald magic things
    public float LightingOnWetEnemyModifier;
    public float BurnDamagePerSekund;

    public float damageAdvanced; 
    public float damageDisadvanced; 



    //MagicTypes.Magictype
    public enum Magictype 
    {
        none,
        FireMagic,
        IceMagic,
        LightingMagic,
        WindMagic,
        plantMagic,
        RockMagic,
        WaterMagic,
        EnergyMagic
    }


    //MagicTypes.magicEffects
    public enum magicEffects
    {
        none,
        BurningEffect,
        FrozenEffect,
        WetEffect
  
    }

}
