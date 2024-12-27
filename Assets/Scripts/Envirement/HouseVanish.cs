using System;
using UnityEngine;

public class HouseVanish : MonoBehaviour
{
    SpriteRenderer houseSR;
    public SpriteRenderer[] otherObejctSR;
    public float Transparency;
    public float TransparencySpeed;
    float TransparencyValue;

    public GameObject Ground;
    int stage;

    void Start()
    {
        houseSR = GetComponent<SpriteRenderer>();
        houseSR.sortingOrder = 10;

        foreach (var Obejct in otherObejctSR)
        {
            Obejct.sortingOrder = 10+1;
        }
        stage = 0;

    }

    void FixedUpdate()
    {
        switch (stage)
        {
            case 0: //neutral
            TransparencyValue = 1;

            break;
            case 1: //fade in
            
            if (TransparencyValue < 1f)
            {
                TransparencyValue += TransparencySpeed;
            }    

            break;
            case -1: //fade out
            
            if (TransparencyValue > Transparency)
            {
                TransparencyValue -= TransparencySpeed;
            }  

            break;



        }

        //transparet changes
        houseSR.color = new Color(houseSR.color.r, houseSR.color.g, houseSR.color.b, TransparencyValue);
        foreach (var Obejct in otherObejctSR)
        {
            Obejct.color = new Color(Obejct.color.r, Obejct.color.g, Obejct.color.b, TransparencyValue);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //detect player
        if ((other.CompareTag("Player") && other.transform.Find("Foot") != null) || (other.CompareTag("Enemy") && other.transform.Find("Foot") != null))
        {
            if (Ground.transform.position.y < other.transform.Find("Foot").position.y)
            {
                stage = -1;
                houseSR.sortingOrder = 10;
                foreach (var Obejct in otherObejctSR)
                {
                    Obejct.sortingOrder = 10+1;
                }
                
            }
            else 
            {
                houseSR.sortingOrder = 0;
                foreach (var Obejct in otherObejctSR)
                {
                    Obejct.sortingOrder = 1;
                }
            }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //detect player
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            stage = 1;
            houseSR.sortingOrder = 10;
            foreach (var Obejct in otherObejctSR)
            {
                Obejct.sortingOrder = 10+1;
            }
        }

    }


}
