using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject prefab;
    
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("izik");
            SpawnMissile();
        }
    }

    void SpawnMissile()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = spawnPos.position;
    }
}
