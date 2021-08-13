using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private Transform player;


    [SerializeField] private Transform spawnPositions;
    
    [SerializeField]
    private int wantedNumber;
    private int obsticalesOnFront;
    private int obsticalesOnBack;

    [SerializeField] private List<GameObject> prefabs;

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
        grid = new Grid(startPos,spacingX,spacingZ,rows,cols);
        playerStartZ = player.transform.position.z;
        for (int i = 0; i < rows*cols; i++)
        {
            spawnPoses.Add(new Vector3(0,0,0));
        }
        SpawnObstacles(wantedNumber);
        StartCoroutine(up());
    }


    IEnumerator up()
    {
        maxCarsONGrid = 100;
        while (wantedNumber < maxCarsONGrid)
        {
            yield return new WaitForSeconds(10f);
            wantedNumber++;
        }
    }

    void Update()
    {
        delta = player.transform.position.z - playerStartZ;
        if (ShouldSpawn())
        {
            SpawnObstacles(wantedNumber);
        }

    }

    private bool ShouldSpawn()
    {
        bool spawn = !(maxCar.position.z + spacingZ - 300f > startPos.z + delta);

        return spawn;
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
        if (go.transform.position.z > maxCar.position.z)
            maxCar = go.transform;
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

    


    public Spawner()
    {
        maxCarsONGrid = max_cars_on_grid;
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



