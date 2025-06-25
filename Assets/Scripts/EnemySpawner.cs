using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<WaveConfigSO> waves;
    int currentWaveIndex = 0;

    public WaveConfigSO GetCurrentWave()
    {
        return waves[currentWaveIndex];
    }
    void Start()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            WaveConfigSO wave = waves[i];
            if (wave  == null)
            {
                Debug.LogError($"WaveConfigSO at index {i} is null.");
                break;
            }
            StartCoroutine(SpawnEnemies(wave));
            currentWaveIndex = i;
        }
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemies(WaveConfigSO currentWave)
    {
        Debug.Log($"Spawning enemies for wave: {currentWave.name}");
        if (currentWave == null)
        {
            Debug.LogError("Current wave is not set.");
            yield return null;
        }
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            GameObject enemyPrefab = currentWave.GetEnemyPrefab(i);
            if (enemyPrefab != null)
            {
                Transform spawnPoint = currentWave.GetStartingWaypoint();
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform);
            }
            else
            {
                Debug.LogError($"Enemy prefab at index {i} is null.");
            }
            yield return new WaitForSeconds(currentWave.GetSpawnTime());
        }
    }
}
