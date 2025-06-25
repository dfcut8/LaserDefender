using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveConfigSO currentWave;

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        if (currentWave == null)
        {
            Debug.LogError("Current wave is not set.");
            return;
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
        }
    }
}
