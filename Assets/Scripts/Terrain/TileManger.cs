using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class TileManger : MonoBehaviour
{

    [SerializeField] private Transform[] floors;

    [SerializeField] private Transform[] borders;

    [SerializeField]
    private string[] prefabs;

    private float currentZ = 0;

    [SerializeField]
    private Vector3 startPos;

	[SerializeField]
    private float tileLength = 10.1f;

    private List<Tuple<GameObject,Transform>> tiles = new List<Tuple<GameObject, Transform>>();

    [SerializeField]
    private Transform player;

    [SerializeField] private Transform borderLeft;
    [SerializeField] private Transform borderRight;
    void Start()
    {
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        SpawnTile(false);
        currentBorderZ += 500;

    }
    [SerializeField]
    private float floorCurrentZ;
    [SerializeField]
    private float currentBorderZ;

    private int currentFloorZ = 1900;

    void Update()
    {
        foreach (var tile in tiles)
        {

            if (tile.Item2.position.z + tileLength / 2f + 40f < player.position.z)
            {
                PlaceInFront(tile.Item1, tileLength,ref currentZ);
            }
        }

        foreach (var floor in floors)
        {
            if (floor.position.z + 2400 < player.position.z)
            {
                floor.gameObject.transform.position = new Vector3(floor.transform.position.x,
                    floor.transform.position.y, currentFloorZ);
                currentFloorZ += 1900;
            }
        }
        bool borderMoved = false;
        foreach (var border in borders)
        {
            if (border.position.z + 700 < player.position.z)
            {
                //currentBorderZ += 500;
                borderMoved = true;
                border.gameObject.transform.position = new Vector3(border.transform.position.x, border.transform.position.y, currentBorderZ);
            }
            
        }

        if (borderMoved)
            currentBorderZ += 500;
    }

    void SpawnTile(bool moveBorder = true)
    {
        GameObject go = ObjectPool.Instance.GetObject(prefabs[Random.Range(0, prefabs.Length)]);
        tiles.Add(Tuple.Create(go,go.transform));
        PlaceInFront(go ,tileLength, ref currentZ);
    }

    void PlaceInFront(GameObject go , float objectLength,ref float currentZ)
    {
        go.transform.position = new Vector3(startPos.x,startPos.y,startPos.z + currentZ);
        currentZ += objectLength;
    }
}
