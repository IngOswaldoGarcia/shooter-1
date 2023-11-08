using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab of the object you want to respawn.
    public Transform spawnPoint; // The position where the object should respawn.
    private float respawnInterval = 9.0f; // The time interval for respawning (in seconds).

    private void Start()
    {
        // Start the coroutine to respawn objects.
        StartCoroutine(RespawnObjects());
    }

    private IEnumerator RespawnObjects()
    {
        while (true) // Infinite loop to keep respawning.
        {
            // Instantiate the object at the spawn point.
            Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
            // Wait for the specified respawn interval.
            yield return new WaitForSeconds(respawnInterval);


        }
    }
}
