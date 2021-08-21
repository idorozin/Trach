using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject prefab;
    [SerializeField] private SwipeDetector swipeDetector;
    public int misiiles;

    private void Start()
    {
        swipeDetector.SwipeDetected += Fire;
    }

    void Fire(string swipeDirection)
    {
        if (swipeDirection != "Down")
            return;
        
        if (misiiles > 0)
        {
            SpawnMissile();
            misiiles--;
        }
    }

    void SpawnMissile()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = spawnPos.position;
    }
}
