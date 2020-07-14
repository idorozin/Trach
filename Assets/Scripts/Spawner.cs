using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    [SerializeField] private float spacing;
    [SerializeField] private float minmaxX;
    

    [SerializeField]
    private int wantedNumber;
    private int obsticalesOnFront;
    private int obsticalesOnBack;

    [SerializeField]
    private GameObject obstaclePrefab;

    private List<GameObject> obstacles = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        obsticalesOnBack = 0;
        obsticalesOnFront = 0;
        CountObstaclesInRange();
  
        SpawnObstacles(wantedNumber-(obsticalesOnBack+obsticalesOnFront));
    }

    private void SpawnObstacles(int number)
    {
        for (var i = 0; i < number; i++)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        float x = Random.Range(-minmaxX, minmaxX);
        int side = Random.Range(0, 2);
        Debug.Log(side);
        float z = 0;
        if (side == 0)
        {
            z = Random.Range(player.transform.position.z - spacing, player.transform.position.z - distance);
        }
        else
        {
            z = Random.Range(player.transform.position.z + spacing, player.transform.position.z + distance);
        }

        GameObject go = Instantiate(obstaclePrefab);
        go.transform.position = new Vector3(x,1f,z);
        obstacles.Add(go);
    }


    private void CountObstaclesInRange()
    {
        foreach (var obstacle in obstacles)
        {
            if (obstacle == null)
            {
                continue;
            }
            if(player == null)
                return;
            var obstaclePos = obstacle.transform.position;
            var playerPos = player.transform.position;
            if (Vector3.Distance(obstacle.transform.position, player.position) +1f < distance)
            {
                if (obstaclePos.z > playerPos.z)
                {
                    obsticalesOnFront++;
                }
                else
                {
                    obsticalesOnBack++;
                }
            }
        }
    }
}
