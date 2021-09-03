using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField]
    private int missileAmount = 3;
    public static event Action<int> missilesCollected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrackSides"))
        {
            missilesCollected(missileAmount);
            Destroy(this.gameObject);
        }
    }
}
