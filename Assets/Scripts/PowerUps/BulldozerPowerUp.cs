using System;
using UnityEngine;

public class BulldozerPowerUp : PowerUpBehaviour
{
    public GameObject bulldozer;
    protected override Evt GetPowerUpEvent() => EventManager.Instance.onBulldozerPowerUp;

    public override void BeginPowerUp()
    {
       bulldozer.SetActive(true);
    }

    public override void EndPowerUp()
    {
        bulldozer.SetActive(false);
    }
}