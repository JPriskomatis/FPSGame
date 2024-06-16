using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints; // Array of spawn points
    [SerializeField] private GameObject enemyPrefab; // Enemy prefab to spawn



    private void Update()
    {
        // Check for input or other conditions to spawn enemies
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Choose a random spawn point
        GameObject spawnPoint = GetRandomSpawnPoint();

        // If a spawn point is available
        if (spawnPoint != null)
        {
            // Instantiate enemy at the selected spawn point
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

    private GameObject GetRandomSpawnPoint()
    {
        // Shuffle the spawnPoints array to randomize spawn selection
        ShuffleArray(spawnPoints);

        // Iterate through shuffled array to find an available spawn point
        foreach (GameObject spawnPoint in spawnPoints)
        {
            // Check if the spawn point is not occupied by an enemy
            if (!IsSpawnPointOccupied(spawnPoint))
            {
                return spawnPoint;
            }
        }

        // No available spawn points
        return null;
    }

    private bool IsSpawnPointOccupied(GameObject spawnPoint)
    {
        // Implement logic to check if the spawn point is occupied by an enemy
        // For simplicity, you can check if the spawn point has a child object (enemy)
        return spawnPoint.transform.childCount > 0;
    }

    // Helper method to shuffle an array
    private void ShuffleArray(GameObject[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}