using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    float timerPoints = 0;
    public int points = 0;
    [SerializeField] Text pointsText;

    private void Start()
    {
        pointsText.text = "Points " + points;
    }
    void Update()
    {
        timerPoints += Time.deltaTime;
        if(timerPoints >=5)
        {
            timerPoints = 0;
            points++;
            pointsText.text = "Points " + points;
        }

    }
}
