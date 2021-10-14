using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    private float minX = -4;
    private float maxX = 4;

    [SerializeField]
    private float minTime;
    [SerializeField]
    private float maxTime;

    private float spawnTime;

    [SerializeField]
    private float distance;

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float height;
    [SerializeField]
    private Transform player;

    [SerializeField]
    private ProbabilityItemPool probabilityItemPool;

    [SerializeField]
    private GameObject flyPrefab;
    [SerializeField]
    private GameObject bulldozerPrefab;

    void Start()
    {
        spawnTime = Time.time + Random.Range(minTime, maxTime);
    }

    void Update()
    {
        if (Time.time > spawnTime)
        {
            spawnTime = Time.time + Random.Range(minTime, maxTime);
            SpawnPowerUpCoin();
        }
    }

    private void SpawnPowerUpCoin()
    {
        string choice = probabilityItemPool.GetRandomItem();
        GameObject go = null;
        if (choice == "fly")
        {
            go = Instantiate(flyPrefab);
        }
        else if (choice == "bulldozer")
        {
            go = Instantiate(bulldozerPrefab);
        }
        else
        {
            go = Instantiate(prefab);
        }

        go.transform.position =
            new Vector3(Random.Range(minX, maxX), height, player.transform.position.z + distance);
    }
}
