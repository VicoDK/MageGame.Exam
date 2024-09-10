using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class multi : MonoBehaviour
{
    public TMP_Text Multi;
    public TMP_Text ScoreText;
    public TMP_Text prise;

    public TMP_Text PasivIncomePrise;
    public TMP_Text PasivIncomeScore;

    private int passivAmount = 1;
    private int passivAmountv2= 0;

    // Start is called before the first frame update
    public void Buy()
    {   if (clicker.score >= 10*clicker.Multyplier)
        {
            clicker.score = clicker.score-10*clicker.Multyplier;
            clicker.Multyplier++;
            ScoreText.text = ("Score : " + clicker.score);
            Multi.text = ("Multiplier : " + clicker.Multyplier);

            prise.text = ("Prise : " + 10*clicker.Multyplier);
        }
        
    }

    public void BuyPasivIncome()
    {
        if (clicker.score >= 10*passivAmount)
        {
            clicker.score = clicker.score-10*passivAmount;
            clicker.Passivincome++;
            passivAmount++;
            passivAmountv2++;

            ScoreText.text = ("Score : " + clicker.score);
            PasivIncomeScore.text = ("Passiv Clickers : " + passivAmountv2);
            PasivIncomePrise.text = ("Prise : " + 10*passivAmount);
        }
            
    }

}
