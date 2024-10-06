using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnabler : MonoBehaviour
{
    
    public bool enabler;

    public GameObject UI;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (enabler)
            {

                UI.SetActive(true);

            }
            else if (!enabler)
            {
                UI.SetActive(false);

            }


        }



    }


}
