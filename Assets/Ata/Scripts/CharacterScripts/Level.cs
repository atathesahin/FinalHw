using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Transform[] teleportPoints;
    [SerializeField] Transform[] safeTeleport;
    public int level = 1;
    [SerializeField] private int _currentExperience = 0;
    [SerializeField] Experience _experience;
    private PlayerMovement _player;
    private float _maxHealth;
    private float increaseDamage;
    private EnemyScriptable _enemyScriptable;
    


    int _teleportInterval = 4;
    int _specialTeleportInterval = 17;
    private int _safeTeleportPoint = 0;
    private int _currentLevel;
    private int _currentTeleportPoint = 0;

    public GameObject[] weapons;
    private int currentWeaponIndex = 0;
    
    //

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        _experience.UpdateExperience(_currentExperience,TO_LEVEL_UP);
        _experience.SetLevelText(level);
        _player = GetComponent<PlayerMovement>();
        UpdateWeapon();
    }

    private void Update()
    {

        LoopLevel();
        ChangeWeapon();
        
    }


    private void LoopLevel()
    {
        
        if (level % _teleportInterval == 0 && level != _currentLevel)
        {
            _currentLevel = level;
            //TeleportToNextPoint();
            TeleportToNextPoint(teleportPoints);
            _player.TeleportShader();

        }
        else if (level % _teleportInterval == 3 && level != _currentLevel) {
            _currentLevel = level;

            SafeTeleportToNextPoint(safeTeleport);
           

        }
        CameraScript.Instance.CarmeraNextRoom();
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Safe"))
        {
            TeleportToNextPoint(teleportPoints);
        }
    }

    public void AddExperience(int amount)
    {
        _currentExperience += amount;
        CheckLevelUp();
        _experience.UpdateExperience(_currentExperience,TO_LEVEL_UP);
    }

    private void CheckLevelUp()
    {
        if (_currentExperience >= TO_LEVEL_UP)
        {
            _currentExperience -= TO_LEVEL_UP;
            level += 1;
            //_maxHealth = GetComponent<PlayerMovement>()._maxHp += 10;
            _experience.SetLevelText(level);
        }
    }



    void TeleportToNextPoint(Transform[] points) 
    {
  
        Transform teleportPoint = points[_currentTeleportPoint];
        _player.transform.position = teleportPoint.position;
        _player.transform.LookAt(teleportPoint);
    
        
        _currentTeleportPoint++;
        if (_currentTeleportPoint >= points.Length) {
            _currentTeleportPoint = 0;
        }
    }

    void SafeTeleportToNextPoint(Transform[] points)
    {
        Transform safePoint = points[_safeTeleportPoint];
        _player.transform.position = safePoint.position;
        _player.transform.LookAt(safePoint);

        _safeTeleportPoint++;

        if (_safeTeleportPoint >= points.Length)
        {
            _safeTeleportPoint = 0;
        }
    }

    void ChangeWeapon()
    {

        if (level == 4 && currentWeaponIndex != 1)
        {
            currentWeaponIndex = 1; // 
            UpdateWeapon();
        }

        if (level == 8 && currentWeaponIndex != 2)
        {
            currentWeaponIndex = 2; // 
            UpdateWeapon();
        }
        if (level == 12 && currentWeaponIndex != 3)
        {
            currentWeaponIndex = 3; // 
            UpdateWeapon();
        }
        if (level == 16 && currentWeaponIndex != 4)
        {
            currentWeaponIndex = 4; // 
            UpdateWeapon();
        }
        if (level == 20 && currentWeaponIndex != 5)
        {
            currentWeaponIndex = 5; // 
            UpdateWeapon();
        }
       
     
    }

    void UpdateWeapon()
    {

        Transform weaponHolder = transform.Find("WeaponHolder");


        for (int i = 0; i < weaponHolder.childCount; i++)
        {
            weaponHolder.GetChild(i).gameObject.SetActive(false);
        }
        weapons[currentWeaponIndex].SetActive(true);
    }

/*
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }
        */

    }

