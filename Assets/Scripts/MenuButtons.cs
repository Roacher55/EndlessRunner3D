using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject canvasMenu;
    [SerializeField] GameObject canvasPoints;
    [SerializeField] Text pointsText;
    [SerializeField] Text firstPlaceText;
    [SerializeField] Text secundPlaceText;
    [SerializeField] Text thiedPlaceText;
   


    private void Start()
    {
        Time.timeScale = 0;
        if (PlayerPrefs.HasKey("LastGamePoints"))
        {
            pointsText.text = "Last Game Points " + PlayerPrefs.GetInt("LastGamePoints");
        }
        else
        {
            pointsText.text = "Last Game Points 0"; 
        }


        if (PlayerPrefs.HasKey("FirstPlace"))
        {
            firstPlaceText.text = "First Place Points " + PlayerPrefs.GetInt("FirstPlace");
        }
        else
        {
            firstPlaceText.text = "First Place Points 0";
            PlayerPrefs.SetInt("FirstPlace", 0);
        }


        if (PlayerPrefs.HasKey("SecundPlace"))
        {
            secundPlaceText.text = "Secund Place Points " + PlayerPrefs.GetInt("SecundPlace");
        }
        else
        {
            secundPlaceText.text = "Secund Place Points 0";
            PlayerPrefs.SetInt("SecundPlace", 0);
        }


        if (PlayerPrefs.HasKey("ThirdPlace"))
        {
            thiedPlaceText.text = "Third Place Points " + PlayerPrefs.GetInt("ThirdPlace");
        }
        else
        {
            thiedPlaceText.text = "Third Place Points 0";
            PlayerPrefs.SetInt("ThirdPlace", 0);
        }
    }
    public void StartButton()
    {
        canvasMenu.SetActive(false);
        canvasPoints.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
