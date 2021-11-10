using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
  
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        temp.z = -10f;
        transform.position = temp;
    }
}
