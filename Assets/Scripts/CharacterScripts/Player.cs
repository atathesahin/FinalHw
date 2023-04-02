using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MainManager _mainManager;
    private EnemyScript _enemyScript;
    
    private RaycastHit _raycastHit;
    private Ray _ray;

    //[SerializeField] private Transform _point;
    [SerializeField] private GameObject _prefab;
    
    [SerializeField] private ParticleSystem speedSystem;
    [SerializeField] private ParticleSystem explosionSystem;

    [SerializeField] private float maxHp = 100;
    [SerializeField] private float currentHp;

    public GameObject speedUp;


    private float _verticalInput;
    private float _horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private BarStatus _status;
    private float shotTime;
    private float shotInterval = 0.2f;
    private bool _hasSpeedup;
    private Vector3 movement;
    
    void Start()
    {
        _status.SetState(currentHp,maxHp);
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.position = transform.position;
        HandleShoot();
        
          
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
      
    }

    void HandleMovement()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        movement = new Vector3(_horizontalInput, 0, _verticalInput);
        transform.Translate(movement * (speed * Time.deltaTime) ,Space.World);
    }

    void HandleRotation()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            transform.LookAt(new Vector3(_raycastHit.point.x,transform.position.y,_raycastHit.point.z));
            
           /* 
            if (_raycastHit.collider.CompareTag("Enemy"))
            {
                _raycastHit.collider.GetComponent<EnemyScript>().TakenDamage(1);
            
            }
            */
          
        }
        
    }

    void HandleShoot()
    {
        
        if (Input.GetMouseButtonDown(0) && Time.time > shotTime)
        {
            Instantiate(explosionSystem, _raycastHit.point, Quaternion.identity);
            shotTime = Time.time + shotInterval;
            
            
            if (_raycastHit.collider.CompareTag("Enemy"))
            {
                _raycastHit.collider.GetComponent<EnemyScript>().TakenDamage(15);
            
            }
            
            
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Speedup"))
        {
            _hasSpeedup = true;
            Destroy(other.gameObject);
            speedUp.gameObject.SetActive(true);
            StartCoroutine(SpeedupCount());
            speed = 35;
            Instantiate(speedSystem, other.transform.position + new Vector3(0,1,0), transform.rotation);
        }
        
        
        
       
    }

    private IEnumerator SpeedupCount()
    {
        yield return new WaitForSeconds(7);
        _hasSpeedup = false;
        speed = 10;
        speedUp.gameObject.SetActive(false);
    }

    

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            
        }
        _status.SetState(currentHp,maxHp);
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0)
        {
            return;
        }

        currentHp += amount;

        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        _status.SetState(currentHp,maxHp);
    }
    
}
