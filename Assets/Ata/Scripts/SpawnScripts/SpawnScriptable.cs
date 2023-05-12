using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Spawner")]
public class SpawnScriptable : ScriptableObject
{
    [field: SerializeField]
    public GameObject[] EnemiesInWave { get; private set; }
    [field: SerializeField]
    public float TimeBeforeThisWave { get; private set; }
    [field: SerializeField]
    public float NumberToSpawn { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
