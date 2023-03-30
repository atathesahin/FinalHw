using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MainManager _mainManager;
    private Enemy _enemy;
    
    private RaycastHit _raycastHit;
    private Ray _ray;

    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject minimap;
    [SerializeField] private ParticleSystem speedSystem;
    [SerializeField] private ParticleSystem shootSystem;


    public GameObject speedUp;

  
    private float _verticalInput;
    private float _horizontalInput;
    [SerializeField] private float speed;

    private float shotTime;
    private float shotInterval = 0.2f;
    private bool hasSpeedup;
    private Vector3 movement;
    
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.position = transform.position;
        HandleShoot();
        MiniMap();
          
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
        }
    }

    void HandleShoot()
    {
        
        if (Input.GetMouseButtonDown(0) && Time.time > shotTime)
        {
            Instantiate(_prefab, _point.transform.position, _point.rotation);
            shotTime = Time.time + shotInterval;
            Instantiate(shootSystem, _point.transform.position, _point.rotation);
        

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Speedup"))
        {
            hasSpeedup = true;
            Destroy(other.gameObject);
            speedUp.gameObject.SetActive(true);
            StartCoroutine(SpeedupCount());
            speed = 35;
            Instantiate(speedSystem, other.transform.position + new Vector3(0,1,0), transform.rotation);
        }
        
       
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody _enemyrigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

        }
        
    }

    private IEnumerator SpeedupCount()
    {
        yield return new WaitForSeconds(7);
        hasSpeedup = false;
        speed = 10;
        speedUp.gameObject.SetActive(false);
    }

    void MiniMap()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            minimap.gameObject.SetActive(true);
        }
        else
        {
            minimap.gameObject.SetActive(false);
        }
    }
    
}
