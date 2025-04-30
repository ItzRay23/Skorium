using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform spawnerTransform;

    [SerializeField]
    private float minX = -1.5f;
    [SerializeField]
    private float maxX = 1.6f;
    [SerializeField]
    private float minY = -1.0f;
    [SerializeField]
    private float maxY = 1.6f;
    [SerializeField]
    private float stepSize = 0.3f;
    [SerializeField, Range(0, 30)]
    private int targetCount;
    [SerializeField]
    private bool spawnMax = false;

    private ArrayList generatePositions()
    {
        ArrayList arr = new ArrayList();
        // Generate all possible positions within the defined area and step size
        if (arr.Count == 0)
        {
            for (float x = minX; x <= maxX; x += stepSize)
            {
                for (float y = minY; y <= maxY; y += stepSize)
                {
                    arr.Add(new TargetPosition(x, y));
                }
            }
        }
        return arr;
    }

    private Vector3 SpawnRandomizer(ArrayList Positions)
    {
        // If no positions are left, return Vector3.zero (or handle as needed)
        if (Positions.Count == 0)
        {
            //Debug.LogWarning("No more unique positions available for spawning.");
            return Vector3.zero;
        }

        // Select a random position from the available positions
        int randomIndex = Random.Range(0, Positions.Count);
        TargetPosition position = (TargetPosition)Positions[randomIndex];
        Positions.RemoveAt(randomIndex); // Remove the position to avoid reuse
        
        // Ensure the position is unique by checking against existing children
        foreach (Transform child in spawnerTransform)
        {
            Vector3 childPosition = child.position;
            if (Mathf.Approximately(childPosition.x, spawnerTransform.position.x + position.GetPosX()) &&
                Mathf.Approximately(childPosition.y, spawnerTransform.position.y + position.GetPosY()))
            {
                //Debug.LogWarning("Duplicate position detected. Retrying...");
                return SpawnRandomizer(Positions); // Retry to find a unique position
            }
        }

        // Return the calculated world position
        return new Vector3(spawnerTransform.position.x + position.GetPosX(),
                           spawnerTransform.position.y + position.GetPosY(),
                           spawnerTransform.position.z);

    }

    private void SpawnMaxTargets() {
        ArrayList Positions = generatePositions();
        for (int i = 0; i < Positions.Capacity; i++) {
            Vector3 spawnPosition = SpawnRandomizer(Positions);
            GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            target.transform.SetParent(spawnerTransform); // Set the parent to the spawner object
            target.name = "Target" + (i + 1); // Name the target for easier identification
        }
        Positions.Clear();
    }

    public void SpawnTargets()
    {
        ArrayList Positions = generatePositions();
        for (int i = 0; i < targetCount; i++)
        {
            Vector3 spawnPosition = SpawnRandomizer(Positions);
            GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            target.transform.SetParent(spawnerTransform); // Set the parent to the spawner object
            target.name = "Target" + (i + 1); // Name the target for easier identification
            Debug.Log("Spawned " + targetCount.ToString() + " Target(s)!");
        }
        Positions.Clear();
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
        if (spawnMax)
        {
            SpawnMaxTargets();
        } else
        {
            SpawnTargets();
        }
    }
}
