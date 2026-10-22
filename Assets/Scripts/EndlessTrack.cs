using UnityEngine;
using System.Collections.Generic;

public class EndlessTrack : MonoBehaviour
{
    public GameObject trackPrefab;
    public Transform player;

    public float sectionLength = 30f;
    public int sectionsAhead = 5;

    private float nextSpawnZ = 0f;

    private List<GameObject> activeSections =
        new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < sectionsAhead; i++)
        {
            SpawnSection();
        }
    }

    void Update()
    {
        if (player.position.z + (sectionsAhead * sectionLength)
            > nextSpawnZ)
        {
            SpawnSection();
        }

        // Remove old sections behind the player
        while (activeSections.Count > 0 &&
               activeSections[0].transform.position.z
               + sectionLength < player.position.z - sectionLength)
        {
            Destroy(activeSections[0]);
            activeSections.RemoveAt(0);
        }
    }

    void SpawnSection()
    {
        Vector3 spawnPosition =
            new Vector3(0f, 0f, nextSpawnZ);

        GameObject section = Instantiate(
            trackPrefab,
            spawnPosition,
            Quaternion.identity
        );

        activeSections.Add(section);
        nextSpawnZ += sectionLength;
    }
}