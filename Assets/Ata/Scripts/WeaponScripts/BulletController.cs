using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private WeaponManager _weaponManager;
    public float bulletLifetime = 3f;
    
    private float _bulletDamage = 25f;
    [SerializeField] private float bulletSpeed;
    private float _currentLifetime = 0f;
    private Rigidbody _rigidbody;
    private TrailRenderer _trail;
    private EnemyController _enemyController;
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

        _rigidbody.velocity = transform.forward * bulletSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyHealth = collision.gameObject.GetComponent<EnemyController>();
            if (enemyHealth != null)
            {
                enemyHealth.TakenDamage(_bulletDamage);
          
            
            }
        }
        Destroy(gameObject);
    }
  
 
}
