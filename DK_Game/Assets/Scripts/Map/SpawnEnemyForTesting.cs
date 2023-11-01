using UnityEngine;

public class SpawnEnemyForTesting : MonoBehaviour
{
    public GameObject enemyPrefab;

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
