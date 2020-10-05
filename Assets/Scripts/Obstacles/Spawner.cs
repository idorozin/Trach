using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Object = System.Object;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    [SerializeField] private float spacing;
    [SerializeField] private float minmaxX;


    [SerializeField] private Transform spawnPositions;
    
    [SerializeField]
    private int wantedNumber;
    private int obsticalesOnFront;
    private int obsticalesOnBack;

    [SerializeField] private List<GameObject> prefabs;
    private List<GameObject> obstacles = new List<GameObject>();
    [SerializeField]
    private float radius = 10;

    [SerializeField]
    private int UPPER;

    [SerializeField]
    private float Xsize = 1.5f;
    [SerializeField]
    private float Ysize = 1f;
    [SerializeField]
    private float Zsize = 4f;



    private float playerStartZ;

    private float zGridStartPos;

    [SerializeField]
    private ProbabilityItemPool randomObject;

    private ObjectPool pool;
    
    void Start()
    {
        pool = ObjectPool.Instance;
        grid = new Grid(startPos,spacingX,spacingZ,rows,cols);
        playerStartZ = player.transform.position.z;
        SpawnObstacles(wantedNumber);
        StartCoroutine(up());
    }


    IEnumerator up()
    {
        while (wantedNumber < 100)
        {
            yield return new WaitForSeconds(10f);
            wantedNumber++;
        }
    }

    void Update()
    {
        delta = player.transform.position.z - playerStartZ;
        zGridStartPos = obstacles.Any() ? obstacles.Max(x => x.transform.position.z) + Zsize : Zsize;
        if(ShouldSpawn())
            SpawnObstacles(wantedNumber);

    }

    private bool ShouldSpawn()
    {
        bool spawn = true;
        foreach (GameObject obstacle in obstacles)     
        {
            if (obstacle == null)
            {
                continue;
            }

            if (obstacle.transform.position.z + spacingZ - 300f > startPos.z + delta  )
            {
                spawn = false;
                break;
            }
        }

        return spawn;
    }

    private void SpawnObstacles(int number)
    {
        zGridStartPos = obstacles.Any() ? obstacles.Max(x => x.transform.position.z) + Zsize : Zsize;
        List<Vector3> spawnPoses = new List<Vector3>();


        foreach (var node in grid.grid)
        {
            spawnPoses.Add(node.position);
        }
        
        
        for (var i = 0; i < number; i++)
        {
            SpawnObstacle(spawnPoses);
        }

    }

    [SerializeField]
     Transform spawn;

    [ContextMenu("spawn obstacle")]
    private void spawnobstacle()
    {
        SpawnObstacles(wantedNumber);
    }

    private void SpawnObstacle(List<Vector3> spawnPositions)
    {

        Vector3 randomPoint = GetRandomPoint(spawnPositions);
        if (randomPoint == null)
        {
            return;
        }
        
        string randomPrefab = GetRandomTag();

        GameObject go = ObjectPool.Instance.GetObject(randomPrefab);
        go.transform.position = new Vector3(randomPoint.x,1f,randomPoint.z);   
        obstacles.Add(go);
    }

    private Vector3 GetRandomPoint(List<Vector3> spawnPositions)
    {
        Vector3 randomPos = spawnPositions[Random.Range(0, spawnPositions.Count)];
        spawnPositions.Remove(randomPos);
        randomPos.z = randomPos.z + zGridStartPos +spacingZ+startPos.z*-1;
        return randomPos;

    }

    private string GetRandomTag()
    {
        return randomObject.GetRandomItem();
    }


    private void CountObstaclesInRange()
    {
        foreach (var obstacle in obstacles)
        {

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
    
    public float spacingX;
    public float spacingY = 0f;
    public float spacingZ;
    public Vector3 startPos;
    public int rows;
    public int cols;
    private float delta;

    private void OnDrawGizmos()
    {

        grid = new Grid(startPos,spacingX,spacingZ,rows,cols);

        Gizmos.color = Color.blue;
        foreach (Node node in grid.grid)
        {
            Gizmos.DrawCube(node.position+new Vector3(0f,0.5f,zGridStartPos+spacingZ+startPos.z*-1),new Vector3(Xsize,Ysize,Zsize));
        }
    }
    
    
    
}



