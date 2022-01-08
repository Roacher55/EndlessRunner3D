using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLoop : MonoBehaviour
{
    [SerializeField] Transform road1Transform;
    [SerializeField] Transform road2Transform;
    float destination;
    [SerializeField] float speed =5f;

    private void Start()
    {
        destination = -road2Transform.position.z;
    }
    void Update()
    {
        if (road1Transform.position.z >= destination)
        {
            road1Transform.position = new Vector3(road1Transform.position.x, road1Transform.position.y, 0);
            road2Transform.position = new Vector3(road2Transform.position.x, road2Transform.position.y, - destination);
        }
        else
        {
            road1Transform.position = new Vector3(road1Transform.position.x, road1Transform.position.y, road1Transform.position.z + speed * Time.deltaTime);
            road2Transform.position = new Vector3(road2Transform.position.x, road2Transform.position.y, road2Transform.position.z + speed * Time.deltaTime);
        }            
    }
}
