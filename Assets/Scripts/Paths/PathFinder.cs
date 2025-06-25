using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogError("EnemySpawner not found in the scene.");
        }
    }

    void Start()
    {
        var wave = enemySpawner.currentWave;
        waypoints = wave.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Transform targetWaypoint = waypoints[waypointIndex];
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetWaypoint.position,
                enemySpawner.currentWave.moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
