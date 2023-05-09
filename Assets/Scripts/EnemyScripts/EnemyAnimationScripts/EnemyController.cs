using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    
    //[SerializeField] private Transform target;
    private GameObject _player;
    private NavMeshAgent _agent;
    public float distance;
    private PlayerMovement player;
    [SerializeField] private int experienceReward = 2500;
    [SerializeField] private float enemyDamage = 10;
    [SerializeField] private float enemyHealth = 50;
    
    //
    private BoxCollider _boxCollider;
   
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        _player = GameObject.Find("Player");
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _boxCollider = GetComponentInChildren<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("speed",_agent.velocity.magnitude);
        distance = Vector3.Distance(transform.position, _player.transform.position);
        _agent.destination = _player.transform.position;

        if (distance <= 10)
        {
            _agent.enabled = true;
        }

        if (distance <= 3)
        {
            Attack();
        }
    }

     private void OnTriggerEnter(Collider other)
     { 
         var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            
            player.TakeDamage(enemyDamage);
          
        }
        
      
    }

    void Attack()
    {
        _animator.SetTrigger("Attack");
        _agent.SetDestination(transform.position);
    }

    public void TakenDamage(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 1)
        {
            _player.GetComponent<Level>().AddExperience(experienceReward);
            Destroy(gameObject);
    
            
        }
        
    }

    void EnableAttack()
    {
        _boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        _boxCollider.enabled = false;
    }


    
    
    
    

}
