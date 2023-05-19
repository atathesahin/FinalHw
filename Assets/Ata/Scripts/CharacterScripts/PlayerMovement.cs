using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private LayerMask _aimLayerMask;

    private Animator _animator;
    
    [SerializeField] private BarStatus _status;
    [SerializeField] Text healthText;
    public float _maxHp = 100;
    public float _currentHp = 100;
    private float healTime;
    private float hpReg = 0.1f;

    //
    public bool isDead = false;
    
    //
    
    private void Awake() => _animator = GetComponent<Animator>();
    
    void Start()
    {

        _status.SetState(_currentHp,_maxHp);
        _status.GetComponent<BarStatus>();


    }
    void Update()
    {
        if (isDead == false)
        {
            gameObject.transform.position = transform.position;
            healthText.text = _currentHp + "/" + _maxHp.ToString();
            
            AimTowardMouse();
            Movement();
            HealReg();
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _animator.SetTrigger("idleFire");
                
                isDead = false;
            }
        }
        

    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= _speed * Time.deltaTime;
            transform.Translate(movement,Space.World);
            
        }

        if (movement.magnitude > 0 && Input.GetKey(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Fire");
        }
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        
        _animator.SetFloat("VelocityZ",velocityZ);
        _animator.SetFloat("VelocityX",velocityX);

  
    }
    void AimTowardMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _aimLayerMask))
        {
            var _direction = hitInfo.point - transform.position;
            _direction.y = 0f;
            _direction.Normalize();
            transform.forward = _direction;
            isDead = false;
        }
    }
    public void TakeDamage(float damage)
    {
        _animator.SetTrigger("Hit");
        _currentHp -= damage;
        if (_currentHp <= 0)
        {
            _animator.SetTrigger("Death");
            isDead = true;
            ES3.DeleteFile("AutoSave.es3");
            
        }
        _status.SetState(_currentHp,_maxHp);
    }

    

    private void Heal(int amount)
    {
        if (_currentHp <= 0)
        {
           
            //return;
        }

        _currentHp += amount;

        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
        _status.SetState(_currentHp,_maxHp);
        
    }

    private void HealReg()
    {
        if (_currentHp <= 100 && Time.time > healTime)
        {
            Heal(1);
            healTime = Time.time + hpReg;
    

        }
    }
  
}
