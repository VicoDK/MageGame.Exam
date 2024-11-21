using UnityEngine;

public class MagicTypes : MonoBehaviour
{
    //generald magic things
    public float LightingOnWetEnemyModifier;
    public float BurnDamagePerSekund;



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
        BurningEffect,
        FrozenEffect,
        WetEffect,
        none
    }

}
