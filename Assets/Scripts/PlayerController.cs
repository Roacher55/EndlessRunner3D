using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject canvasMenu;
    [SerializeField] PauseGame pauseGame;
    [SerializeField] Transform playerPosition;
    [SerializeField] Points points;
    float  timerNextMove = 0.25f;
    float moveBy = 0.5f;

    // Update is called once per frame
    void Update()
    {
        SpaceGame();
        PlayerMove();
    }

    void SpaceGame()
    {
        if (canvasMenu.activeSelf == false && Input.GetKeyDown("space"))
        {
            if (Time.timeScale == 0)
            {
                pauseGame.Resume();
            }
            else
            {
                pauseGame.Pause();
            }
        }
    }

    void PlayerMove()
    {
       if(Input.GetKey(KeyCode.LeftArrow) && playerPosition.position.x <= 2f && timerNextMove<=0)
        {
            playerPosition.position = new Vector3(playerPosition.position.x + moveBy, playerPosition.position.y, playerPosition.position.z);
            timerNextMove = 0.5f;
        }
        else if(Input.GetKey(KeyCode.RightArrow) && playerPosition.position.x >= -2f && timerNextMove <= 0)
        {
            playerPosition.position = new Vector3(playerPosition.position.x - moveBy, playerPosition.position.y, playerPosition.position.z);
            timerNextMove = 0.5f;
        }
        timerNextMove -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            PlayerPrefs.SetInt("LastGamePoints", points.points);

            List<int> playerPrefs = new List<int>();
            playerPrefs.Add(PlayerPrefs.GetInt("FirstPlace"));
            playerPrefs.Add(PlayerPrefs.GetInt("SecundPlace"));
            playerPrefs.Add(PlayerPrefs.GetInt("ThirdPlace"));

            var tempScore = points.points;
            for (int i = 0; i < playerPrefs.Count; i++)
            {
                if (tempScore > playerPrefs[i])
                {
                    int temp = playerPrefs[i];
                    playerPrefs[i] = tempScore;
                    tempScore = temp;
                }
            }
            PlayerPrefs.SetInt("FirstPlace", playerPrefs[0]);
            PlayerPrefs.SetInt("SecundPlace", playerPrefs[1]);
            PlayerPrefs.SetInt("ThirdPlace", playerPrefs[2]);

            PlayerPrefs.Save();

            RoadLoop.speed = 5f;
            ObstacleController.speedSpawn = 5;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
