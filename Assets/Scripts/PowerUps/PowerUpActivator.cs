

using System;
using UnityEngine;
public abstract class PowerUpActivator : MonoBehaviour
{
    [SerializeField] private IDestroyable destroyable; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrackSides"))
        {
            ActivatePowerUp();
            destroyable.Destroy();
        }
    }

    private void ActivatePowerUp()
    {
        GetPowerUpEvent().Invoke();
    }

    protected abstract Evt GetPowerUpEvent();
}
