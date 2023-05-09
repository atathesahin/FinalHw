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
    public GameObject[] weapons;
    
    
    int teleportInterval = 5;
    int specialTeleportInterval = 4;


    private int currentWeaponIndex = 0;
    
    private int currentLevel;
    private int currentTeleportPoint = 0;

    private int safeTeleportPoint = 0;
    
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
    void LoopLevel()
    {
        if (level % teleportInterval == 0 && level != currentLevel)
        {
            currentLevel = level;
            //TeleportToNextPoint();
            TeleportToNextPoint(teleportPoints);
   
        }
        else if (level % specialTeleportInterval == 0 && level != currentLevel) {
            currentLevel = level;
            
            SafeTeleportToNextPoint(safeTeleport);
            
        }

        CameraScript.Instance.CarmeraNextRoom();
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
            _maxHealth = GetComponent<PlayerMovement>().maxHp += 10;
            _experience.SetLevelText(level);
        }
    }



    void TeleportToNextPoint(Transform[] points) 
    {
  
        Transform teleportPoint = points[currentTeleportPoint];
        _player.transform.position = teleportPoint.position;
        _player.transform.LookAt(teleportPoint);
    
        
        currentTeleportPoint++;
        if (currentTeleportPoint >= points.Length) {
            currentTeleportPoint = 0;
        }
    }

    void SafeTeleportToNextPoint(Transform[] points)
    {
        Transform safePoint = points[safeTeleportPoint];
        _player.transform.position = safePoint.position;
        _player.transform.LookAt(safePoint);

        safeTeleportPoint++;

        if (safeTeleportPoint >= points.Length)
        {
            safeTeleportPoint = 0;
        }
    }

    void ChangeWeapon()
    {
        if (level >= 5 && currentWeaponIndex != 1)
        {
            currentWeaponIndex = 1; // ikinci silahın dizin numarası
            UpdateWeapon();
        }
        else if (level >= 10 && currentWeaponIndex != 2)
        {
            currentWeaponIndex = 2; // üçüncü silahın dizin numarası
            UpdateWeapon();
        }
    }

    void UpdateWeapon()
    {
        GameObject weaponParent = transform.Find("WeaponHolder").gameObject;


        weaponParent.SetActive(false);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);  
            
        }

        weapons[currentWeaponIndex].SetActive(true);;
    }
}
