using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Vector3 point;
    public float speedFast = 15;
    void Start()
    {
        point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (speedFast * Time.deltaTime));
 
    }
}
