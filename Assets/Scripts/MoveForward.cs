using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private EnemyScript _enemyScript;
    private Vector3 point;
    public float speedFast = 15;

    public float damage = 5;
    //[SerializeField] private float damage = 5;
    void Start()
    {
        point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (speedFast * Time.deltaTime));
      
 
    }
    
    

   
    private void OnTriggerEnter(Collider other)
    {
       
        Destroy(other.gameObject);
    }
   
   
}
