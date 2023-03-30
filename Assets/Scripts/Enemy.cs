using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody _enemyrigidbody;
    private GameObject player;
    [SerializeField] private ParticleSystem explosion;
    void Start()
    {
        _enemyrigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = ((player.transform.position - transform.position).normalized * speed);
        _enemyrigidbody.AddForce(lookAt);

        if (transform.position.y < -10)
        {
            Destroy(gameObject); 
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
    }
}
