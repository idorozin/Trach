using System;
using UnityEngine;

public class BulldozerPowerUp : PowerUpBehaviour
{
    public GameObject bulldozer;
    protected override Evt GetPowerUpEvent() => EventManager.Instance.onBulldozerPowerUp;

    protected override void BeginPowerUp()
    {
       bulldozer.SetActive(true);
    }

    protected override void EndPowerUp()
    {
        bulldozer.SetActive(false);
    }
}