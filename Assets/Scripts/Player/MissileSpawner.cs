using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject prefab;
    public int misiiles;


    void Update()
    {
   
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (misiiles > 0)
                {
                    Debug.Log("izik");
                    SpawnMissile();
                    misiiles--;
                }
            }

    }

    void SpawnMissile()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = spawnPos.position;
    }
}
