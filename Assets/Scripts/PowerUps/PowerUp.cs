
using System;
using System.Collections;
using UnityEngine;

public abstract class PowerUpBehaviour : MonoBehaviour
{
    protected abstract Evt GetPowerUpEvent();

    private void OnEnable()
    {
        GetPowerUpEvent().Subscribe(PowerUp);
    }
    
    [SerializeField]
    private float powerUpDuration;


    private void OnDisable()
    {
        GetPowerUpEvent().UnSubscribe(PowerUp);
    }

    public void PowerUp()
    {
        StartCoroutine(_PowerUp());
    }

    private IEnumerator _PowerUp()
    {
        BeginPowerUp();
        yield return new WaitForSeconds(powerUpDuration);
        EndPowerUp();
    }

    protected abstract void BeginPowerUp();
    protected abstract void EndPowerUp();
}
