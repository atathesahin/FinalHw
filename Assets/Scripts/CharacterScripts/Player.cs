using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private MainManager _mainManager;
    private EnemyScript _enemyScript;
    private Level _level;
 
    private RaycastHit _raycastHit;
    private Ray _ray;

    //[SerializeField] private Transform _point;
    //[SerializeField] private GameObject _prefab;
    
    [SerializeField] private ParticleSystem speedSystem;
    //[SerializeField] private ParticleSystem explosionSystem;
    
   
    private bool isDead;

    public GameObject speedUp;

    private float _verticalInput;
    private float _horizontalInput;
    public float speed;
    
    [SerializeField] private BarStatus _status;
    [SerializeField] Text healthText;
    public float maxHp = 100;
    public float currentHp;
    
    private float shortTime;
    private float healTime;
    private float shotInterval = 0.2f;
    private float hpReg = 0.1f;
    private bool _hasSpeedup;
    private Vector3 movement;
    
    void Start()
    {
        _status.SetState(currentHp,maxHp);
        _status.GetComponent<BarStatus>();
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.position = transform.position;
        healthText.text = currentHp + "/" + maxHp.ToString();
        //HandleShoot();
        
        HealReg();
          
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

   /*
    void HandleShoot()
    {
        
        if (Input.GetMouseButtonDown(0) && Time.time > shortTime)
        {
            Instantiate(explosionSystem, _raycastHit.point, Quaternion.identity);
            shortTime = Time.time + shotInterval;
            
            
            if (_raycastHit.collider.CompareTag("Enemy"))
            {
                _raycastHit.collider.GetComponent<EnemyScript>().TakenDamage(10);
            
            }
            
            
        }
        

    }
    */

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

  

    private void Heal(int amount)
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

    private void HealReg()
    {
        if (currentHp <= 100 && Time.time > healTime)
        {
            Heal(1);
            healTime = Time.time + hpReg;
            
        }
        
        
    }

}
