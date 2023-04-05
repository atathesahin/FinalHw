using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private Transform target;
    private NavMeshAgent _agent;
    public float distance;


    void Start()
    {

        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("speed",_agent.velocity.magnitude);
        distance = Vector3.Distance(transform.position, target.position);
        _agent.destination = target.position;

        if (distance <= 10)
        {
            _agent.enabled = true;
        }   
        
        

    }

}
