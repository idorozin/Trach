

using System;
using UnityEngine;
public abstract class PowerUpActivator : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrackSides"))
        {
            ActivatePowerUp();
            Destroy(this.gameObject);
        }
    }

    private void ActivatePowerUp()
    {
        GetPowerUpEvent().Invoke();
    }

    protected abstract Evt GetPowerUpEvent();
}
