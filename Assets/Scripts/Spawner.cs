using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    
    public GameObject[] enemyPrefab;
    //public GameObject[] bossPrefab;
    public GameObject power;

    public int enemyCount;

    public TextMeshProUGUI waveScore;
    private int wave;
    public int difficult;
    public int waveNumber = 1;
    
    float spawnY = (float)0.5;
    
    

    private float spawnRange = 20;
    void Start()
    {
        SpawnEnemy(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            difficult = waveNumber / 2;
            SpawnEnemy(waveNumber);
            waveScore.text = "Wave: " + waveNumber;
            Instantiate(power, GenerateSpawn(), power.transform.rotation);
           
        }

        
    }

    Vector3 GenerateSpawn()
    {
        float spawnposX = Random.Range(-spawnRange, spawnRange);
        float spawnposZ = Random.Range(-spawnRange, spawnRange);
        

        Vector3 randomPos = new Vector3(spawnposX, spawnY, spawnposZ);

        return randomPos;

    }

    private int GenerateRandomEnemy()
    {
        int randomEnemy = Random.Range(0, DifficultLevel());
        return randomEnemy;
    }

    void SpawnEnemy(int enemies)
    {
        for (int i = 0; i < enemies; i++)
        {
            Instantiate(enemyPrefab[GenerateRandomEnemy()], GenerateSpawn(), enemyPrefab[GenerateRandomEnemy()].transform.rotation);
        }
    }

    private int DifficultLevel()
    {
        if (difficult > enemyPrefab.Length)
        {
            difficult = enemyPrefab.Length;
        }

        return difficult;
    }

    private void AddWave()
    {
        
    }
}
