using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaveiour : MonoBehaviour, IPooledObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrackSides"))
        {
            ReturnToPool();
        }
    }

    public string Tag { get; set; }
    public void ReturnToPool()
    {
        ObjectPool.Instance.ReturnObject(Tag,gameObject);
    }
}
