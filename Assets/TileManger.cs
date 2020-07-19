using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TileManger : MonoBehaviour
{

    

    [SerializeField]
    private GameObject[] prefabs;

    private float currentZ;

    [SerializeField]
    private Vector3 startPos;

    private float tileLength = 10;

    private List<GameObject> tiles = new List<GameObject>();

    [SerializeField]
    private Transform player;

    [SerializeField] private Transform borderLeft;
    [SerializeField] private Transform borderRight;
    void Start()
    {
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
    }

    void Update()
    {
        foreach (var tile in tiles)
        {

            if (tile.transform.position.z + tileLength/2f+0.1f < player.position.z)
            {
                PlaceInFront(tile);
            }
        }

    }

    void SpawnTile()
    {
        GameObject go = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
        tiles.Add(go);
        PlaceInFront(go);
    }

    void PlaceInFront(GameObject go)
    {
        go.transform.position = new Vector3(startPos.x,startPos.y,startPos.z + currentZ);
        currentZ += tileLength;
        borderLeft.transform.position = new Vector3(borderLeft.transform.position.x,borderLeft.transform.position.y,borderLeft.transform.position.z + tileLength);
        borderRight.transform.position = new Vector3(borderRight.transform.position.x,borderRight.transform.position.y,borderRight.transform.position.z + tileLength);
    }
}
