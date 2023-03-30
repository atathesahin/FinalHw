using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyScriptable enemyScriptable = null;
    private GameObject _player;
    private Rigidbody _rigidbody;
    void Start()
    {
        enemyScriptable.enemyColor = GetComponent<Renderer>().material.color;
       _rigidbody = GetComponent<Rigidbody>();
       _player = GameObject.Find("Player");
       enemyScriptable.enemyScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = ((_player.transform.position - transform.position).normalized * enemyScriptable.enemySpeed);
        _rigidbody.AddForce(lookAt);

        if (transform.position.y < -10)
        {
            Destroy(gameObject); 
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(enemyScriptable.explosion, transform.position, enemyScriptable.explosion.transform.rotation);
    }
}
