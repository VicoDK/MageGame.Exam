using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NextText : MonoBehaviour
{
    private PlayerStats PlayerStat;
    public GameObject nextText;
    public GameObject LastText;
    public GameObject PlayerUI; 

    public bool first;

    void Update()
    {
        if (Controls.PInput.actions["Enter"].WasPressedThisFrame())
        {
            if (nextText != null)
            {
                nextText.SetActive(true);
            }
            else 
            {
                PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
                Time.timeScale = 1;
                PlayerUI.SetActive(true); //diable player ui
                PlayerStat.Shopping = false;
            }

            this.gameObject.SetActive(false);

        } 
    }

    public void Next()
    {
        if (nextText != null)
        {
            nextText.SetActive(true);
        }
        else 
        {
            PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
            Time.timeScale = 1;
            PlayerUI.SetActive(true); //diable player ui
            PlayerStat.Shopping = false;
        }

        this.gameObject.SetActive(false);
    }


    private void OnEnable() //on enable 
    {
        if (first)
        {
            PlayerStat = GameObject.Find("PlayerBody").GetComponent<PlayerStats>();
            PlayerUI = GameObject.Find("PlayerCanvas");
            PlayerUI.SetActive(false); //diable player ui
            PlayerStat.Shopping = true; //stops the player from moving
            LastText.GetComponent<NextText>().PlayerUI = PlayerUI;
            Time.timeScale = 0;
        }


        
    }

}
