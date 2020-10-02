using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class FastCarSpawner : MonoBehaviour
{

    [SerializeField] private float[] roadX;

    [SerializeField] private Transform player;

    [SerializeField] private Movement movement;

    [SerializeField] private int minTime;
    [SerializeField] private int maxTime;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float maxDist;
    [SerializeField] private float minDist;

    void Start()
    {
        spawnTime = 30f;
    }

    void Update()
    {
        if (Time.time > spawnTime)
        {
            SpawnCar();
            spawnTime = GetSpawnTime();
        }
    }

    private float GetSpawnTime()
    {
        return Time.time + Random.Range(minTime, maxTime);
    }

    private void SpawnCar()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = player.transform.position - new Vector3(0f, 0f, Random.Range(minDist, maxDist));
        go.transform.position = new Vector3(roadX[Random.Range(0,roadX.Length)] , go.transform.position.y,go.transform.position.z);
        
    }
}
