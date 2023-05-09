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
    [SerializeField] private int enemyDamage;
    [SerializeField] private float enemyHealth = 50;
    
    //
   
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        _player = GameObject.Find("Player");
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    


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
        
        

    }
    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject == _player)
        {
           
            Attack();
         

        }
    }

    private void Attack()
    {
        if (player == null)
        {
            player = _player.GetComponent<PlayerMovement>();
            
          
        }
        player.TakeDamage(enemyDamage);
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


    
    
    
    

}
