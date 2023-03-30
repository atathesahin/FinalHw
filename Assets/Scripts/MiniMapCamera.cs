using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPoisiton = player.position;
        newPoisiton.y = transform.position.y;
        transform.position = newPoisiton;
    }
}
