using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private Grid grid;

    [SerializeField]
    private float minTime;
    [SerializeField]
    private float maxTime;
    
    private float spawnTime;
    [SerializeField]
    private string CoinTag;

    private float minX = 1f;
    private float maxX = 8f;

    private void Start()
    {
        grid.SetUpGrid();
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
        float zGridStartPos = GameManager.Instance.playerpos.transform.position.z + 100f;
        float xPos = Random.Range(minX, maxX - grid.spacingX*(grid.cols-1));
        Vector3 final_pos = new Vector3(xPos, 1f, zGridStartPos);
        SpawnCoinPattern(final_pos, grid.grid);

    }

    public void SpawnCoinPattern(Vector3 position, Node[,] pattern)
    {
        foreach (var node in pattern)
        {
            GameObject go = ObjectPool.Instance.GetObject(CoinTag);
            go.transform.position = new Vector3(node.position.x + position.x,position.y,node.position.z + position.z);
        }
    }
    
}
