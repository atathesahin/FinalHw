using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletLifetime = 3f;
    
    [SerializeField] float bulletDamage = 10f;
    private float currentLifetime = 0f;
    

    void Update()
    {
        currentLifetime += Time.deltaTime;
        
        //transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));
        
        if (currentLifetime >= bulletLifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemyHealth = collision.gameObject.GetComponent<EnemyScript>();
            if (enemyHealth != null)
            {
                enemyHealth.TakenDamage(bulletDamage);
            }
        }
        Destroy(gameObject);
    }
}
