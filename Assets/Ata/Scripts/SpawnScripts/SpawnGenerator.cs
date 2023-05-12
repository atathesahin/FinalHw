using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    public SpawnScriptable[] waves;
    private SpawnScriptable currentWave;
    
    [SerializeField] private Transform[] spawnpoints;
    private float _timeSpawns = 1;
    private int i = 0;
    private bool _stopSpawning = false;
    
    private float spawnRange = 70;
    float spawnY = (float)0.5;
    
    void Awake()
    {
        currentWave = waves[i];
        _timeSpawns = currentWave.TimeBeforeThisWave;
    }

    // Update is called once per frame
    void Update()
    {
        if (_stopSpawning)
        {
            return;
        }

        if (Time.time >= _timeSpawns)
        {
            SpawnWave();
            IncWave();
            _timeSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }
    }

    private void IncWave()
    {
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            //int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, spawnpoints.Length);
            

            Instantiate(currentWave.EnemiesInWave[num], GenerateSpawn(),
                spawnpoints[num2].rotation);
        }
    }

    private void SpawnWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            _stopSpawning = true;
        }
    }
    Vector3 GenerateSpawn()
    {
        float spawnposX = Random.Range(-spawnRange, spawnRange);
        float spawnposZ = Random.Range(-spawnRange, spawnRange);
        

        Vector3 randomPos = new Vector3(spawnposX, spawnY, spawnposZ);

        return randomPos;

    }
}
