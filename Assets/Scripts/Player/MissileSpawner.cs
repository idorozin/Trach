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
        EventManager.Instance.onSwipeDetected.Subscribe(Fire);
        EventManager.Instance.onMissilesCollected.Subscribe(OnMissilesCollected);
    }

    private void OnMissilesCollected()
    {
        missiles += 3;
        EventManager.Instance.onMissilesChanged.Invoke(missiles);
    }

    void Fire(string swipeDirection)
    {
        if (swipeDirection != "Down")
            return;
        
        if (missiles > 0)
        {
            SpawnMissile();
            missiles--;
            EventManager.Instance.onMissilesChanged.Invoke(missiles);
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

}
