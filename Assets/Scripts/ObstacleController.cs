using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]List<Obstacle> obstacles;
    float timeeSpawn = 5f;
    public static float speedSpawn = 5f;
    private void Update()
    {
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        if (timeeSpawn <= 0)
        {
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index], new Vector3(Random.Range(-2f, 2f), 0f, -25f), Quaternion.identity);
            timeeSpawn = speedSpawn;
        }
        timeeSpawn -= Time.deltaTime;
    }
}
