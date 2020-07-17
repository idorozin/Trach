using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    [SerializeField] private float spacing;
    [SerializeField] private float minmaxX;


    [SerializeField] private Transform spawnPositions;
    
    [SerializeField]
    private int wantedNumber;
    private int obsticalesOnFront;
    private int obsticalesOnBack;

    [SerializeField]
    private GameObject obstaclePrefab;

    [SerializeField] private List<GameObject> prefabs;
    private List<GameObject> obstacles = new List<GameObject>();
    [SerializeField]
    private float radius = 10;

    void Start()
    {
        
    }

    void Update()
    {
        obsticalesOnBack = 0;
        obsticalesOnFront = 0;
        CountObstaclesInRange();
        SpawnObstacles(wantedNumber-(obsticalesOnFront));
    }

    private void SpawnObstacles(int number)
    {
        if (number > 0)
        {
            SpawnObstacle();
        }
        /*int j = 0;
        for (var i = 0; i < number; i++)
        {
            j++;
            SpawnObstacle();
        }
        Debug.Log("spawned: " + j);*/

    }

    private void SpawnObstacle()
    {

        List<Vector3> avilablePoints = new List<Vector3>();
        foreach (Transform child in spawnPositions)
        {
            Collider[] hitColliders = Physics.OverlapBox(child.position + new Vector3(0f,0.5f,0f),new Vector3(1.5f,1f,4f));
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
        if(!avilablePoints.Any())
            return;
        var randomPoint = avilablePoints[Random.Range(0, avilablePoints.Count - 1)];
        var randomPrefab = prefabs[Random.Range(0, prefabs.Count - 1)];

        GameObject go = Instantiate(randomPrefab);

        go.transform.position = new Vector3(randomPoint.x,2f,randomPoint.z);
        
        Physics.SyncTransforms();
        obstacles.Add(go);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform child in spawnPositions)
        {
            Gizmos.DrawCube(child.transform.position+new Vector3(0f,0.5f,0f),new Vector3(1.5f,1f,4f));
        }
    }
    
    
    
    
    public static void DrawWireCapsule(Vector3 _pos, Vector3 _pos2, float _radius, float _height, Color _color = default)
    {
        if (_color != default) Handles.color = _color;
 
        var forward = _pos2 - _pos;
        var _rot = Quaternion.LookRotation(forward);
        var pointOffset = _radius/2f;
        var length = forward.magnitude;
        var center2 = new Vector3(0f,0,length);
       
        Matrix4x4 angleMatrix = Matrix4x4.TRS(_pos, _rot, Handles.matrix.lossyScale);
       
        using (new Handles.DrawingScope(angleMatrix))
        {
            Handles.DrawWireDisc(Vector3.zero, Vector3.forward, _radius);
            Handles.DrawWireArc(Vector3.zero, Vector3.up, Vector3.left * pointOffset, -180f, _radius);
            Handles.DrawWireArc(Vector3.zero, Vector3.left, Vector3.down * pointOffset, -180f, _radius);
            Handles.DrawWireDisc(center2, Vector3.forward, _radius);
            Handles.DrawWireArc(center2, Vector3.up, Vector3.right * pointOffset, -180f, _radius);
            Handles.DrawWireArc(center2, Vector3.left, Vector3.up * pointOffset, -180f, _radius);
           
            DrawLine(_radius,0f,length);
            DrawLine(-_radius,0f,length);
            DrawLine(0f,_radius,length);
            DrawLine(0f,-_radius,length);
        }
    }
 
    private static void DrawLine(float arg1,float arg2,float forward)
    {
        Handles.DrawLine(new Vector3(arg1, arg2, 0f), new Vector3(arg1, arg2, forward));
    }

}



