using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public GameObject shopUI; // Alışveriş menüsü
    private PlayerMovement _playerMovement;
    private CoinSystem _coinSystem;
    public int healthUpgradeCost = 10; // Sağlık geliştirme maliyeti
    //public int damageUpgradeCost = 15; // Hasar geliştirme maliyeti
    private float _maxHealth;
    private bool _inTrigger = false;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _coinSystem = GetComponent<CoinSystem>();
    }
    private void Update()
    {
        if (_inTrigger && Input.GetKeyDown(KeyCode.F)) // Tetikleme bölgesindeyken F tuşuna basıldığında
        {
            shopUI.SetActive(true); // Alışveriş menüsünü aç veya kapat
        }
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
            shopUI.SetActive(false); // Alışveriş menüsünü deaktif hale getir
        }
    }

    // Sağlık geliştirmesi satın alma işlemi
    public void UpgradeHealth()
    {
        int upgradeCost = healthUpgradeCost;
        if (_playerMovement != null)
        {
            if (_coinSystem._currentCoin >= upgradeCost)
            {
                _coinSystem._currentCoin -= upgradeCost;
                _playerMovement._maxHp += 10;
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

    // Hasar geliştirmesi satın alma işlemi
    /*
    public void UpgradeDamage()
    {
        int upgradeCost = damageUpgradeCost;

        if (characterStats != null && characterStats.coins >= upgradeCost)
        {
            _coinSystem._currentCoin -= upgradeCost;
            characterStats._speed += 1; // Hasar değerini arttırabilirsiniz
            Debug.Log("Hasar geliştirmesi satın alındı!");
        }
        else
        {
            Debug.Log("Yetersiz bakiye veya karakter özellikleri tanımlı değil!");
        }
    }
    */
}
