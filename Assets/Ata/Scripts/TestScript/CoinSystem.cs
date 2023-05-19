using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public int _currentCoin = 0;
    [SerializeField] private TextMeshProUGUI coinText;
    void Start()
    {
        coinText.text = "Coins: " + _currentCoin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateUI()
    {
        
    }
    public void AddCoin(int amount)
    {
        _currentCoin += amount;
        coinText.text = "Coins: " + _currentCoin.ToString();
    }
}
