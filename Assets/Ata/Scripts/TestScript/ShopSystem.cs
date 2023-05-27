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
    [SerializeField] int _armorCost = 10;// Sağlık geliştirme maliyeti
    //public int damageUpgradeCost = 15; // Hasar geliştirme maliyeti
    private float _maxHealth;
    private bool _inTrigger = false;
    
    
    //
    private bool _isShopOpen = false;

    //
    [SerializeField] TextMeshProUGUI healthUpgradeCostText; // Sağlık geliştirme maliyeti metin bileşeni
    [SerializeField] TextMeshProUGUI hpRegCostText; // Hp regen maliyeti metin bileşeni
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
        if (other.CompareTag("Player")) // Eğer etkileşime geçilen nesne "Player" etiketine sahipse
        {
            _inTrigger = true; // Tetikleme bölgesinde olduğunu belirt
            //_characterStats = other.GetComponent<PlayerMovement>(); // Karakter özelliklerini içeren scripte erişim sağla
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inTrigger = false; // Tetikleme bölgesinden çıktığını belirt
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
                _playerMovement.hpReg += 0.05f;
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
                _playerMovement.currentArmor += 1f;
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
