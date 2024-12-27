using UnityEngine;

public class DialogEffect : MonoBehaviour
{
    public GameObject flame;
    public GameObject gate;

    public void OpenGate()
    {
        Destroy(gate);
    }

    public void StartFlame()
    {
        flame.GetComponent<ObjectEffect>().ObjectEffects(1, MagicTypes.Magictype.FireMagic);
    }
}
