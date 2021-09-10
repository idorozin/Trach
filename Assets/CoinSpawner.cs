using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private Grid grid;

    public int rows = 4;
    public int cols = 1;
    
    
    public float spacingX;
    public float spacingZ;
    [SerializeField]
    private float minTime;
    [SerializeField]
    private float maxTime;

    [SerializeField]    
    private GameObject coin;
    [SerializeField]
    private float distanceFromPlayer;

    private float spawnTime;
    [SerializeField]
    private string CoinTag;

    private float minX = -4f;
    private float maxX = 4f;

    private void Start()
    {
        Vector3 startPos = new Vector3(-3.63f, 0f, -8.1f);
        grid = new Grid(startPos, spacingX, spacingZ, rows, cols);
    }

    private float GetSpawnTime()
    {
        return Time.time + Random.Range(minTime, maxTime);
    }

    void Update()
    {
        if (Time.time > spawnTime)
        {
            SpawnCoins();
            spawnTime = GetSpawnTime();
        }

    }
    
    
    private void SpawnCoins()
    {
        var zGridStartPos = GameManager.Instance.playerpos.transform.position.z + 300f;
        int j = 0;
        float xPos = Random.Range(minX, maxX);
        foreach (var node in grid.grid)
        {
            GameObject go = ObjectPool.Instance.GetObject(CoinTag);
            go.transform.position = new Vector3(xPos,1f,node.position.z + zGridStartPos);
        }
    }
}
