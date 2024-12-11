using UnityEngine;

public class NPCOrderInLayer : MonoBehaviour
{


    public SpriteRenderer  sr;
    public GameObject feet;
    int stage;

    void Start()
    {
        sr.sortingOrder = 10;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //detect player
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            if (feet.transform.position.y < other.transform.position.y-(other.transform.localScale.y/2))
            {
                sr.sortingOrder = 10;

            }
            else 
            {
                sr.sortingOrder = 0;
                
            }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //detect player
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            sr.sortingOrder = 10;

        }

    }
}
