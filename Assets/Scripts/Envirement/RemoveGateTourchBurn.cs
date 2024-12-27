using UnityEngine;

public class RemoveGateTourchBurn : MonoBehaviour
{
    public GameObject Flame;


    // Update is called once per frame
    void Update()
    {
        if (Flame.GetComponent<ObjectEffect>().Burning)
        {
            Destroy(this.gameObject);
        }
    }
}
