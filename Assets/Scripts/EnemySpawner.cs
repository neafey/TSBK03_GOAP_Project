using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public Transform npc; // Reference to the NPC
    public Vector2 spawnAreaMin; // Minimum coordinates for spawn area
    public Vector2 spawnAreaMax; // Maximum coordinates for spawn area
    public float safeRadius = 3f; // Radius around NPC where enemies cannot spawn
    public float minSpawnInterval = 5f; // Minimum time between spawns
    public float maxSpawnInterval = 10f; // Maximum time between spawns
    public int maxEnemies = 10; // Maximum number of enemies allowed
    private int currentEnemyCount = 0; // Current number of spawned enemies

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    System.Collections.IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Wait for a random interval
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            // Skip spawning if maximum enemies are already present
            if (currentEnemyCount >= maxEnemies)
                continue;

            // Generate a random position within the spawn area
            Vector2 spawnPosition;
            do
            {
                spawnPosition = new Vector2(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y)
                );
            }
            while (Vector2.Distance(spawnPosition, npc.position) < safeRadius);

            // Spawn the enemy and update the count
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
