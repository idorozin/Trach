using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

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

    [SerializeField]
    private Car[] cars;

    private float playerStartZ;
    
    
    void Start()
    {
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
        if(ShouldSpawn())
            SpawnObstacles(wantedNumber);
        /*obsticalesOnBack = 0;
        obsticalesOnFront = 0;
        CountObstaclesInRange();
        SpawnObstacles(wantedNumber-(obsticalesOnFront));*/
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

            if (obstacle.transform.position.z + spacingZ > startPos.z + delta )
            {
                spawn = false;
                break;
            }
        }

        return spawn;
    }

    private void SpawnObstacles(int number)
    {

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
        
        GameObject randomPrefab = GetRandomPrefab();

        GameObject go = Instantiate(randomPrefab);
        go.transform.position = new Vector3(randomPoint.x,5f,randomPoint.z);   
        obstacles.Add(go);
    }

    private Vector3 GetRandomPoint(List<Vector3> spawnPositions)
    {
        Vector3 randomPos = spawnPositions[Random.Range(0, spawnPositions.Count)];
        spawnPositions.Remove(randomPos);
        randomPos.z = randomPos.z + delta;
        return randomPos;

        /*Physics.SyncTransforms();
        List<Vector3> avilablePoints = new List<Vector3>();
        foreach (Transform child in spawnPositions)
        {
            Collider[] hitColliders = Physics.OverlapBox(child.position + new Vector3(0f,0.5f,0f),new Vector3(Xsize,Ysize,Zsize));
            bool found = false;
            foreach (var collider in hitColliders)
            {
                if (collider.gameObject.CompareTag("Obstacle"))
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                avilablePoints.Add(child.position);
            }
        }
        return avilablePoints[Random.Range(0, avilablePoints.Count - 1)];*/
    }

    private GameObject GetRandomPrefab()
    {
        int randNum = Random.Range(0, 100);
        foreach (var car in cars)
        {
            if (car.prob.MatchesNum(randNum))
            {
                return car.prefab;
            }

        }

        return null;
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
        /*foreach (Transform child in spawnPositions)
        {
            Collider[] hitColliders = Physics.OverlapBox(child.position + new Vector3(0f,0.5f,0f),new Vector3(Xsize,Ysize,Zsize));
            bool found = false;
            foreach (var collider in hitColliders)
            {
                if (collider.gameObject.CompareTag("Obstacle"))
                {
                    Gizmos.color = Color.red;

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Gizmos.color = Color.green;

            }
            Gizmos.DrawCube(child.transform.position+new Vector3(0f,0.5f,0f),new Vector3(Xsize,Ysize,Zsize));

        }*/

        grid = new Grid(startPos,spacingX,spacingZ,rows,cols);

        Gizmos.color = Color.blue;
        foreach (Node node in grid.grid)
        {
            Gizmos.DrawCube(node.position+new Vector3(0f,0.5f,0f+delta),new Vector3(Xsize,Ysize,Zsize));
        }
    }
    
    
    
}



