using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpriteRenderer : MonoBehaviour
{
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }


}
