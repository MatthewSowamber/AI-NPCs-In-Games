using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject NPCPrefab;
    public float spawnTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPlayer", 0f, 5f);
    }

    void SpawnPlayer()
    {
        Instantiate(NPCPrefab, transform.position, Quaternion.identity);
    }
}
