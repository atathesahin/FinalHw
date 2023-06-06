using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class EnemyController : MonoBehaviour
{
    private Animator _animator;

    //[SerializeField] private Transform target;
    private GameObject _player;
    private NavMeshAgent _agent;
    public float distance;
    private PlayerMovement player;
    public int experienceReward;
    [SerializeField] private float enemyDamage = 10;
    public float _enemyHealth = 50;
    
    //
    private BoxCollider _boxCollider;

    //
    private CapsuleCollider _capsuleCollider;
    private bool isDead = false;
    private bool isAttack = false;
    //
    //private CoinSystem _coin;
    [SerializeField] private int _coinValue;
    [SerializeField] private float MDropChance = 1f / 10f;
    [SerializeField] private GameObject dropObject;
    
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        _player = GameObject.Find("Player");
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _boxCollider = GetComponentInChildren<BoxCollider>();
        _capsuleCollider = GetComponent<CapsuleCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false && isAttack == false)
        {
            
                Movement();
                
        }


    }

    void Movement()
    {
        _animator.SetFloat("speed",_agent.velocity.magnitude);
        
            var position = _player.transform.position;
            distance = Vector3.Distance(transform.position, position);
            _agent.destination = position;



            if (distance >= 40)
        {
            _agent.isStopped = true;
         
        }
        if (distance <= 10)
        {
            _agent.enabled = true;
         

        }
   
        if (distance <= 3.5f )
        {
            Attack();
     

        }
    }
  
    
    void Die()
    {
        _animator.SetTrigger("Death");
        _boxCollider.enabled = false;
        _agent.isStopped = true;
        Drop();
        Destroy(gameObject, 4f);
    }

     private void OnTriggerEnter(Collider other)
     { 
         var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            
            player.TakeDamage(enemyDamage);
            if (player._currentHp <= 0)
            {
                _agent.isStopped = true;
                isAttack = true;

            }
        }
     }

     void Attack()
    {
   
        _animator.SetTrigger("Attack");
        _agent.SetDestination(transform.position);
        isAttack = false;
      

    }

    public void TakenDamage(float damage)
    {
        if (distance >= 6)
        {
            _animator.SetTrigger("Hit");
        }
       
        _enemyHealth -= damage;

        if (_enemyHealth <= 0)
        {
            _player.GetComponent<Level>().AddExperience(experienceReward);
            _player.GetComponent<CoinSystem>().AddCoin(_coinValue);
            Die();
            EnableCollider();
            isDead = true;
       
        }
        
    }
    
    void EnableCollider()
    {
        _capsuleCollider.enabled = false;
    }
    void EnableAttack()
    {
        _boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        _boxCollider.enabled = false;
    }
    private void Drop()
    {
        if (Random.Range(0f, 1f) <= MDropChance)
        {
            Instantiate(dropObject, transform.position + new Vector3(0,1,0), dropObject.transform.rotation);
            
        }
    }
}
