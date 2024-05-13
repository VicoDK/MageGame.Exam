using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //timer variable
    public float Time;
    
    void Start()
    {
        //here we start det Explosion timer
        StartCoroutine(Explode());
    }

    private IEnumerator Explode ()
    {
        //here we wait some seconds
        yield return new WaitForSeconds(Time);
        //here we destroy the explosion after some time
        Destroy(gameObject);
        
    }

}
