using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MissileUI : MonoBehaviour
{

    private Transform grid;

    void Start()
    {
        grid = transform;
        EventManager.Instance.onMissilesChanged.Subscribe(UpdateUI);
    }

    private void UpdateUI(int amount)
    {
        foreach (Transform missileIcon in grid)
        {
            missileIcon.gameObject.SetActive(false);
        }

        int count = 0;
        foreach(Transform missileIcon in grid)
        {
            if (count == amount)
                break;
            count += 1;
            missileIcon.gameObject.SetActive(true);
        }
    }
    
}
