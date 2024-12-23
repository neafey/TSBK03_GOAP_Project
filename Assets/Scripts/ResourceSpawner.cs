using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject[] resourcePrefabs; // Array for prefabs: Food, Wood, Stone
    public Vector2 spawnAreaMin; 
    public Vector2 spawnAreaMax; 
    public float minSpawnInterval = 3f; 
    public float maxSpawnInterval = 10f; 

    void Start()
    {
        StartCoroutine(SpawnResources());
    }

    System.Collections.IEnumerator SpawnResources()
    {
        while (true)
        {
            // Vänta ett slumpmässigt intervall
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            // Slumpa vilken resurs som ska spawnas
            GameObject resourceToSpawn = resourcePrefabs[Random.Range(0, resourcePrefabs.Length)];

            // Slumpa position inom spawn-området
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // Spawn resursen
            Instantiate(resourceToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
