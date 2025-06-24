using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfigSO", menuName = "Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    public List<GameObject> enemyPrefabs;
    public Transform pathPrefab;
    public float moveSpeed = 5f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        if (index < 0 || index >= enemyPrefabs.Count)
        {
            Debug.LogError("Index out of bounds for enemy prefabs.");
            return null;
        }
        return enemyPrefabs[index];
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new();
        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints.Add(pathPrefab.GetChild(i));
        }
        return waypoints;
    }
}
