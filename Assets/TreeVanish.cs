using Unity.VisualScripting;
using UnityEngine;

public class TreeVanish : MonoBehaviour
{
    SpriteRenderer srTree;
    public SpriteRenderer srLeafs;
    public float Transparency;
    public float TransparencySpeed;
    float TransparencyValue;

    public GameObject Root;
    int stage;

    void Start()
    {
        srTree = GetComponent<SpriteRenderer>();
        srTree.sortingOrder = 10;
        srLeafs.sortingOrder = 10+1;
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
        srTree.color = new Color(srTree.color.r, srTree.color.g, srTree.color.b, TransparencyValue);
        srLeafs.color = new Color(srLeafs.color.r, srLeafs.color.g, srLeafs.color.b, TransparencyValue);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //detect player
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            if (Root.transform.position.y < other.transform.position.y-(other.transform.localScale.y/2))
            {
                stage = -1;
                srTree.sortingOrder = 10;
                srLeafs.sortingOrder = 10+1;
            }
            else 
            {
                srTree.sortingOrder = 0;
                srLeafs.sortingOrder = 1;
            }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //detect player
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            stage = 1;
            srTree.sortingOrder = 10;
            srLeafs.sortingOrder = 10+1;
        }

    }


}
