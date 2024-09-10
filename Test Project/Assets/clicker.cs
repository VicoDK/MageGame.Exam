using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clicker : MonoBehaviour
{
    static public int score;
    public TMP_Text ScoreText;

    static public int Multyplier = 1;

    static public int Passivincome;

    public void Start()
    {
        InvokeRepeating("Passiv", 0, 1);
    }
        

    private void OnMouseDown()
    {
        score+= 1 * Multyplier;

        ScoreText.text = ("Score : " + score);

        
    }


    public void Passiv()
    {
        score+= Passivincome;
        ScoreText.text = ("Score : " + score);




    }
}
