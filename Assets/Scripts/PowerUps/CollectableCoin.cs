

using System;
using UnityEngine;
public abstract class CollectableCoin : MonoBehaviour
{
   [SerializeField] private Destroyable destroyable; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrackSides"))
        {
            FireOnCollectEvent();
            destroyable.Destroy();
        }
    }

    private void FireOnCollectEvent()
    {
        GetOnCollectEvent().Invoke();
    }

    public abstract Evt GetOnCollectEvent();
}
