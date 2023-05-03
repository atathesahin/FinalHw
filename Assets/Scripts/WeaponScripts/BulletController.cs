using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private WeaponManager _weaponManager;
    public float bulletLifetime = 3f;
    
    public float bulletDamage = 10f;
    private float currentLifetime = 0f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        currentLifetime += Time.deltaTime;
        
        //transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));
        
        if (currentLifetime >= bulletLifetime)
        {
            Destroy(gameObject);
        }

        _rigidbody.velocity = transform.forward * 25f;
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
