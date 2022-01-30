using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerMenu : MonoBehaviour
{
    [SerializeField] private Grid grid;


    
    [SerializeField]
    private int wantedNumber;
    private int obsticalesOnFront;
    private int obsticalesOnBack;

    [SerializeField]
    private float Xsize = 1.5f;
    [SerializeField]
    private float Ysize = 1f;
    [SerializeField]
    private float Zsize = 4f;



    private float playerStartZ;

    private float zGridStartPos;

    [SerializeField]
    private ProbabilityItemPool<string> randomObject;

    private ObjectPool pool;
    
    List<Vector3> spawnPoses = new List<Vector3>(360);
    
    public float spacingX;
    public float spacingY = 0f;
    public float spacingZ;
    public Vector3 startPos;
    public int rows;
    public int cols;
    private float delta;
    private float maxCarZ;
    private Transform maxCar;
    private int max_cars_on_grid;
    private int maxCarsONGrid;


    void Start()
    {
        pool = ObjectPool.Instance;
        playerStartZ = GameManager.Instance.playerpos.position.z;
        grid = new Grid(startPos,spacingX,spacingZ,rows,cols);
        for (int i = 0; i < rows*cols; i++)
        {
            spawnPoses.Add(new Vector3(0,0,0));
        }
        SpawnObstacles(wantedNumber);
    }
    
    private void SpawnObstacles(int number)
    {
        maxCar = maxCar == null ? transform : maxCar;
        zGridStartPos = maxCar.transform.position.z;
        int j = 0;
        foreach (var node in grid.grid)
        {
            if(j >= spawnPoses.Count)
                spawnPoses.Add(new Vector3(0,0,0));
            spawnPoses[j] = node.position;
            j++;
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

    private List<GameObject> cars = new List<GameObject>();
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
        cars.Add(go);
        if (go.transform.position.z > maxCar.position.z)
            maxCar = go.transform;
    }

    private void Update()
    {
        foreach (var car in cars)
        {
            if (Math.Abs(car.transform.position.z - playerStartZ) > 200)
            {
                car.transform.position = car.transform.position + new Vector3(0, 0, -200f);

            }
        }
    }

    private Vector3 GetRandomPoint(List<Vector3> spawnPositions)
    {
        int random_pos = Random.Range(0, spawnPositions.Count);
        Vector3 randomPos = spawnPositions[random_pos];
        spawnPositions.RemoveAt(random_pos);
        randomPos.z = randomPos.z + zGridStartPos +spacingZ+startPos.z*-1;
        return randomPos;

    }

    private string GetRandomTag()
    {
        return randomObject.GetRandomItem();
    }

    
    

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



