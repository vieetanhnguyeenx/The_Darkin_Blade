using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    public Vector3[] spawnPositions; // An array containing fixed spawn positions
    private int spawnIndex = 0;

    private List<GameObject> pool;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            pool.Add(enemy);
            SpawnFromPool();
        }
    }


    public GameObject SpawnFromPool()
    {
        if (pool == null || pool.Count == 0)
        {
            return null;
        }

        // Choose a spawn position
        Vector3 spawnPosition = spawnPositions[spawnIndex];
        spawnIndex = (spawnIndex + 1) % spawnPositions.Length; // Loop back to the beginning if we've reached the end

        foreach (GameObject enemy in pool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.transform.position = spawnPosition;
                // Set other properties of the enemy (if needed)
                enemy.SetActive(true);
                return enemy;
            }
        }
        return null;
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
