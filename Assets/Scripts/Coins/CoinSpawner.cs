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

    private float minX = -8f;
    private float maxX = 8f;

    [SerializeField] private float[] xSpawnPositions;

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
        float maxX_ = maxX;
        //float xPos = Random.Range(minX, maxX - grid.spacingX*(grid.cols-1));
        List<float> availableX = new List<float>();
        foreach (var posX in xSpawnPositions)
        {
            if (posX > minX && posX < maxX_)
            {
                availableX.Add(posX);
            }
        }
        var index = Random.Range(0, availableX.Count);

        float xPos = availableX[index];
        Debug.Log(xPos);
        Vector3 final_pos = new Vector3(xPos, 1f, zGridStartPos);
        
        SpawnCoinPattern(final_pos, grid.grid);
        

    }

    public void SpawnCoinPattern(Vector3 position, Node[,] pattern)
    {
        foreach (var node in pattern)
        {
            if (!node.used) continue;
            GameObject go = ObjectPool.Instance.GetObject(CoinTag);
            go.transform.position = new Vector3(node.position.x + position.x,position.y,node.position.z + position.z);
        }
    }
    
}
