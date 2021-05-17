using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField]
    GameObject enemyPrefab;
    
    [SerializeField]
    GameObject pathPrefab;
    
    [SerializeField]
    float timeBetweenSpawns = 0.5f;

    [SerializeField]
    float spawnRandomFactor = 0.3f;

    [SerializeField]
    int numberOfEnemies = 5;

    [SerializeField]
    float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints() 
    {
        var list = new List<Transform>();

        // All children of the path (the way points) are included
        // in the transform enumerable
        foreach(Transform child in pathPrefab.transform)
            list.Add(child);

        return list; 
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    
    public float GetMoveSpeed() { return moveSpeed; }
}
