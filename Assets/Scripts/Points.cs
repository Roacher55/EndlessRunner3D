using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    float timerPoints = 0;
    public int points = 0;
    float speedUp = 0;
    [SerializeField] Text pointsText;
    [SerializeField] Text speedUptext;
    

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
            speedUp++;
            pointsText.text = "Points " + points;

            MoveFaster();
        }

    }

    void MoveFaster()
    {
        if (speedUp >= 5 && (RoadLoop.speed<8 || ObstacleController.speedSpawn>2))
        {
            speedUp = 0;
            RoadLoop.speed = RoadLoop.speed + 0.25f;
            ObstacleController.speedSpawn = ObstacleController.speedSpawn - 0.25f;
            speedUptext.gameObject.SetActive(true);
            Invoke("TurnOffText", 5f);
        }
    }

    void TurnOffText()
    {
        speedUptext.gameObject.SetActive(false);
    }
}
