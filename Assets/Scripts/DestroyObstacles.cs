using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
    }
}
