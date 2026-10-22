using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform player;

    public float spawnDistance = 30f;
    public float spawnInterval = 12f;
    public float laneDistance = 2f;
    public float obstacleLifetime = 10f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = player.position.z + spawnDistance;
    }

    void Update()
    {
        if (player.position.z + spawnDistance >= nextSpawnZ)
        {
            SpawnObstacle();
            nextSpawnZ += spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        int lane = Random.Range(0, 3);
        float xPosition = (lane - 1) * laneDistance;

        Vector3 spawnPosition = new Vector3(
            xPosition,
            1f,
            nextSpawnZ
        );

        int randomIndex = Random.Range(0, obstaclePrefabs.Length);

        GameObject selectedObstacle = obstaclePrefabs[randomIndex];

        GameObject obstacle = Instantiate(
            selectedObstacle,
            spawnPosition,
            selectedObstacle.transform.rotation
        );
        Destroy(obstacle, obstacleLifetime);
    }
}