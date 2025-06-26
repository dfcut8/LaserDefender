using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<WaveConfigSO> waves;

    void Start()
    {
        foreach (WaveConfigSO wave in waves)
        {
            if (wave != null)
            {
                Debug.Log($"Wave loaded: {wave.name}");
                StartCoroutine(SpawnEnemies(wave));
            }
            else
            {
                Debug.LogError("WaveConfigSO is null in the waves list.");
            }
        }
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemies(WaveConfigSO currentWave)
    {
        //foreach (WaveConfigSO wave in waves)
        //{
        //    currentWave = wave;
        //    Debug.Log($"Spawning enemies for wave: {currentWave.name}");
        //    for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        //    {
        //        GameObject enemyPrefab = currentWave.GetEnemyPrefab(i);
        //        if (enemyPrefab != null)
        //        {
        //            Transform spawnPoint = currentWave.GetStartingWaypoint();
        //            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform);
        //        }
        //        else
        //        {
        //            Debug.LogError($"Enemy prefab at index {i} is null.");
        //        }
        //        yield return new WaitForSeconds(currentWave.GetSpawnTime());
        //    }
        //    yield return new WaitForSeconds(0f);
        //}
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            GameObject enemyPrefab = currentWave.GetEnemyPrefab(i);
            var pathFinder = enemyPrefab.GetComponent<PathFinder>();
            pathFinder.wave = currentWave;
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
