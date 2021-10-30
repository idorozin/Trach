using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class TileManger : MonoBehaviour
{

    

    [SerializeField]
    private string[] prefabs;

    private float currentZ;

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

    }

    void Update()
    {
        foreach (var tile in tiles)
        {

            if (tile.Item2.position.z + tileLength/2f+40f < player.position.z)
            {
                PlaceInFront(tile.Item1);
            }
        }

    }

    void SpawnTile(bool moveBorder = true)
    {
        GameObject go = ObjectPool.Instance.GetObject(prefabs[Random.Range(0, prefabs.Length)]);
        tiles.Add(Tuple.Create(go,go.transform));
        PlaceInFront(go , moveBorder);
    }

    void PlaceInFront(GameObject go , bool moveBorder = true)
    {
        go.transform.position = new Vector3(startPos.x,startPos.y,startPos.z + currentZ);
        currentZ += tileLength;
		if(moveBorder){
        borderLeft.transform.position = new Vector3(borderLeft.transform.position.x,borderLeft.transform.position.y,borderLeft.transform.position.z + tileLength/2);
        borderRight.transform.position = new Vector3(borderRight.transform.position.x,borderRight.transform.position.y,borderRight.transform.position.z + tileLength/2);
		}
    }
}
