using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public List<WaveConfigSO> waves;

    public UnityEvent<GameObject> OnEnemySpawn;

    void Start()
    {
        foreach (WaveConfigSO w in waves)
        {
            if (w != null)
            {
                Debug.Log($"Wave loaded: {w.name}");
                StartCoroutine(SpawnEnemies(w));
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

    IEnumerator SpawnEnemies(WaveConfigSO wave)
    {
        yield return new WaitForSeconds(wave.delayBeforeStart);
        do
        {
            for (int i = 0; i < wave.GetEnemyCount(); i++)
            {
                GameObject enemyPrefab = wave.GetEnemyPrefab(i);
                var pathFinder = enemyPrefab.GetComponent<PathFinder>();
                pathFinder.wave = wave;
                if (enemyPrefab != null)
                {
                    Transform spawnPoint = wave.GetStartingWaypoint();
                    var instance = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.Euler(0, 0, 180), transform);
                    OnEnemySpawn?.Invoke(instance);
                }
                else
                {
                    Debug.LogError($"Enemy prefab at index {i} is null.");
                }
                yield return new WaitForSeconds(wave.GetSpawnTime());
            }
            yield return new WaitForSeconds(wave.delayAfterEnd);
        } while (wave.isLooping);
    }
}
