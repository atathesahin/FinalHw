using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private WeaponManager _weaponManager;
    public float bulletLifetime = 3f;
    
    public float bulletDamage = 10f;
    private float _currentLifetime = 0f;
    private Rigidbody _rigidbody;
    private TrailRenderer _trail;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _trail = GetComponent<TrailRenderer>();

    }

    void Update()
    {
        _currentLifetime += Time.deltaTime;
        
        //transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));
        
        if (_currentLifetime >= bulletLifetime)
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
