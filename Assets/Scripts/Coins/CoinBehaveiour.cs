using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaveiour : MonoBehaviour
{
    [SerializeField]
    private Destroyable destroyable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrackSides"))
        {
            destroyable.Destroy();
        }
    }
}
