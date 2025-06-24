using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PathConfigSO", menuName = "Path Config")]
public class SOPath0 : ScriptableObject
{
    public Transform pathPrefab;
    public float moveSpeed = 5f;

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
