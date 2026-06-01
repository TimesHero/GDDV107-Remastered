using UnityEngine;

public class ParalaxSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject[] paralaxPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 2f;

    private float timer;

    private void Update()
    {
        if(GameManager.Instance != null)

        //Time.deltaTime is the time in seconds it took to complete the last frame. Adding it to a variable creates a real-time timer, apparently.
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnParalax();
            //Resets the timer to 0 
            timer = 0f; 
        }
    }

    private void SpawnParalax()
    {
        //prevents null error if the arrays are empty
        if (paralaxPrefabs.Length == 0 || spawnPoints.Length == 0) 
            return;

        //should pick random spawn location
        int randomHazardIndex = Random.Range(0, paralaxPrefabs.Length);
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject selectedHazard = paralaxPrefabs[randomHazardIndex];
        Transform selectedSpawnPoint = spawnPoints[randomSpawnIndex];

        //grabs the prefab and spawns a clone at the randomly chosen spawner and with a random rotation.
        Instantiate(selectedHazard, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
    }
}