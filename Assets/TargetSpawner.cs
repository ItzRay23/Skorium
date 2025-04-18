using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public GameObject targetPrefab;
    public Transform SpawnerTransform;

    private Vector3 SpawnRandomizer() {
        float randomX = Random.Range(-1.5f, 1.6f);
        float randomY = Random.Range(-1.5f, 1.6f);

        return new Vector3(SpawnerTransform.position.x + randomX, SpawnerTransform.position.y + randomY, SpawnerTransform.position.z);
    }

    private void SpawnTargets() {
        for (int i = 0; i < 5; i++) {
            Vector3 spawnPosition = SpawnRandomizer();
            GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            target.transform.SetParent(SpawnerTransform); // Set the parent to the spawner object
            target.name = "Target" + i; // Optional: Name the target for easier identification
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTargets();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            foreach (Transform child in transform) {
                Destroy(child.gameObject); // Destroy all existing targets
            }
            SpawnTargets(); // Spawn new targets when the space key is pressed
        }
    }
}
