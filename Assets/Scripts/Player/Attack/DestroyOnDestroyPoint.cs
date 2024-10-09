using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDestroyPoint : MonoBehaviour
{
    public GameObject obj;


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("delete");
            Destroy(obj);//destroy ball
        }
        
    }
}
