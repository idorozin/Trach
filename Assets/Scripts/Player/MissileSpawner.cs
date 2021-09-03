using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject prefab;
    [SerializeField] private SwipeDetector swipeDetector;
    public int missiles;

    private void Start()
    {
        swipeDetector.SwipeDetected += Fire;
        CollectCoin.missilesCollected += OnMissilesCollected;
    }

    private void OnMissilesCollected(int amount)
    {
        missiles += amount;
        missilesChange(missiles);
    }

    void Fire(string swipeDirection)
    {
        if (swipeDirection != "Down")
            return;
        
        if (missiles > 0)
        {
            SpawnMissile();
            missiles--;
            missilesChange(missiles);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire("Down");
        }

    }

    void SpawnMissile()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = spawnPos.position;
    }

    public static event Action<int> missilesChange;
}
