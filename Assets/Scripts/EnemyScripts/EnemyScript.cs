using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyScriptable enemyScriptable = null;
    private GameObject _player;
    private Rigidbody _rigidbody;
    private PlayerMovement player;
    const float MDropChance = 1f / 10f;
    [SerializeField] private int experienceReward = 400;
    public float enemyHealth;

    [SerializeField] float enemySpeed;
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
        Vector3 lookAt = ((_player.transform.position - transform.position).normalized * enemySpeed);
        _rigidbody.AddForce(lookAt);

        if (transform.position.y < -10)
        {
            Destroy(gameObject); 
            
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
        player.TakeDamage(enemyScriptable.enemyDamage);
    }

    public void TakenDamage(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 1)
        {
            _player.GetComponent<Level>().AddExperience(experienceReward);
            Destroy(gameObject);
            Drop();
            
        }
        else
        {
            
        }
    }

    private void Drop()
    {
        if (Random.Range(0f, 1f) <= MDropChance)
        {
            Instantiate(enemyScriptable.dropObject, transform.position + new Vector3(0,-0.4f,0), transform.rotation);
            
        }
    }
}
