using UnityEngine;

public class SwitchInvMenu : MonoBehaviour
{
    public GameObject ItemInv;
    public GameObject SpellInv;

    public void GoToItemInv()
    {
        ItemInv.SetActive(true);
        SpellInv.SetActive(false);
    }

    public void GoToSpellInv()
    {
        ItemInv.SetActive(false);
        SpellInv.SetActive(true);
    }

    void OnEnable()
    {
        ItemInv.SetActive(true);
        SpellInv.SetActive(false);
    }
}
