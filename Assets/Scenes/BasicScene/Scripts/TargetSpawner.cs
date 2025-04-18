using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform spawnerTransform;

    private Vector3 SpawnRandomizer() {
        float randomX = Random.Range(-1.5f, 1.6f);
        float randomY = Random.Range(-1.0f, 1.6f);

        return new Vector3(spawnerTransform.position.x + randomX, spawnerTransform.position.y + randomY, spawnerTransform.position.z);
    }

    private void SpawnTargets() {
        for (int i = 0; i < 10; i++) {
            Vector3 spawnPosition = SpawnRandomizer();
            GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            target.transform.SetParent(spawnerTransform); // Set the parent to the spawner object
            target.name = "Target" + (i + 1); // Optional: Name the target for easier identification
        }
    }

    public void RandomizeTargets() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject); // Destroy all existing targets
        }
        SpawnTargets(); // Spawn new targets when the space key is pressed
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTargets();
    }
}
