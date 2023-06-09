using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public GameObject shopUI; // Alışveriş menüsü
    private PlayerMovement _playerMovement;
    private CoinSystem _coinSystem;

    
    
    [SerializeField] int _healthUpgradeCost = 10;
    [SerializeField] int _hpRegCost = 10;
    [SerializeField] int _armorCost = 10;
    [SerializeField] int _bulletCost = 10;
    private float _maxHealth;
    private bool _inTrigger = false;
    const float MDropChance = 1f / 10f;
    
    
    //
    private bool _isShopOpen = false;

    //
    [SerializeField] TextMeshProUGUI healthUpgradeCostText; 
    [SerializeField] TextMeshProUGUI hpRegCostText; 
    [SerializeField] TextMeshProUGUI armorCostText;

    private List<WeaponSystem> _weaponSystems = new List<WeaponSystem>();
    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        
        WeaponSystem[] weaponSystems = FindObjectsOfType<WeaponSystem>();
        _weaponSystems.AddRange(weaponSystems); // Yeni silahları ekle
        
        _coinSystem = FindObjectOfType<CoinSystem>();


    }

    private void Update()
    {
        if (_inTrigger && Input.GetKeyDown(KeyCode.F)) // Tetikleme bölgesindeyken F tuşuna basıldığında
        {
            shopUI.SetActive(true);
            _isShopOpen = true;
       
             
            foreach (var weaponSystem in _weaponSystems)
            {
                _isShopOpen = true;
                weaponSystem.enabled = false;
            }
       
        }

        UpdateUI();

    }

    private void UpdateUI()
    {
        healthUpgradeCostText.text = "Cost: " + _healthUpgradeCost.ToString();
        hpRegCostText.text = "Cost: " + _hpRegCost.ToString();
        armorCostText.text = "Cost: " + _armorCost.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inTrigger = true; 
            //_characterStats = other.GetComponent<PlayerMovement>(); // Karakter özelliklerini içeren scripte erişim sağla
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inTrigger = false; 
            shopUI.SetActive(false);
        
            foreach (var weaponSystem in _weaponSystems)
            {
                
                    weaponSystem.enabled = true;

            }
   
        }

        UpdateUI();
    }

    public void UpgradeHealth()
    {
        if (_playerMovement != null && _coinSystem != null)
        {
            if (_coinSystem._currentCoin >= _healthUpgradeCost)
            {
                _coinSystem._currentCoin -= _healthUpgradeCost;
                _playerMovement._maxHp += 10;
                _coinSystem.UpdateUI();
                Debug.Log("Sağlık geliştirmesi satın alındı!");
            }
            else
            {
                Debug.Log("Yetersiz bakiye!");
            }
        }
        else
        {
            Debug.Log("Karakter özellikleri tanımlı değil!");
        }
    }
    public void HpReg()
    {
        if (_playerMovement != null && _coinSystem != null)
        {
            if (_coinSystem._currentCoin >= _hpRegCost)
            {
                _coinSystem._currentCoin -= _hpRegCost;
                _playerMovement.hpReg += 0.02f;
                _coinSystem.UpdateUI();
                Debug.Log("Sağlık geliştirmesi satın alındı!");
            }
            else
            {
                Debug.Log("Yetersiz bakiye!");
            }
        }
        else
        {
            Debug.Log("Karakter özellikleri tanımlı değil!");
        }
    }
    public void Armor()
    {
        if (_playerMovement != null && _coinSystem != null)
        {
            if (_coinSystem._currentCoin >= _armorCost)
            {
                _coinSystem._currentCoin -= _armorCost;
                _playerMovement.currentArmor += 0.2f;
                _coinSystem.UpdateUI();
                Debug.Log("Sağlık geliştirmesi satın alındı!");
            }
            else
            {
                Debug.Log("Yetersiz bakiye!");
            }
        }
        else
        {
            Debug.Log("Karakter özellikleri tanımlı değil!");
        }
    }
}
