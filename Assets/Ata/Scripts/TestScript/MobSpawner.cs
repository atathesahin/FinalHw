using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MobSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Düşmanın prefabı
    public int spawnCount = 10;  // Toplam spawn edilecek düşman sayısı
    public float spawnInterval = 1.0f;  // Her spawn aralığı
    public LayerMask spawnLayer;  // Spawn yapılacak layer
    public float spawnRadius = 5f;
    private int currentSpawned = 0;  // Şu ana kadar spawn edilen düşman sayısı
    
    private void Start()
    {
        // Player karakterin Collider bileşenine bu scriptin etkileşimini sağlamak için
        // gerekli kodu ekleyin veya gerekli eventleri kullanın.
        // Örneğin: playerCollider.OnTriggerEnter += OnTriggerEnter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Belirli aralıklarla SpawnEnemy() fonksiyonunu çağırarak düşmanları spawn eder
            InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);

            // Karakter collideri üzerindeki Is Trigger özelliği etkisizleştirilir
            // Bu, spawn işlemi bittikten sonra tekrar etkileşime girmeyi sağlar
            GetComponent<Collider>().isTrigger = false;
        }
    }

    private void SpawnEnemy()
    {
        if (currentSpawned >= spawnCount)
        {
            // Toplam spawn edilecek düşman sayısına ulaşıldıysa spawn işlemi durdurulur
            CancelInvoke("SpawnEnemy");
            return;
        }

        // Spawn yapılacak layera sahip bir yüzey bulunur
        Vector3 spawnPoint = FindSpawnPoint();

        if (spawnPoint != Vector3.zero)
        {
            // Düşman prefabından yeni bir düşman oluşturulur ve spawn noktasına yerleştirilir
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            currentSpawned++;
        }
    }

    private Vector3 FindSpawnPoint()
    {
        Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
        randomPoint.y = 0f; // Spawn yapılacak yükseklik sıfırlanır

        randomPoint += transform.position; // Spawn yapılacak alanın merkezi eklenir

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, spawnRadius, NavMesh.AllAreas))
        {
            return hit.position; // Geçerli bir spawn noktası bulunursa döndürülür
        }

        return Vector3.zero;
    }
}
