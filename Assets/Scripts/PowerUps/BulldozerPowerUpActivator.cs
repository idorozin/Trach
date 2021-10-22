using System;
using UnityEngine;


public class BulldozerPowerUpActivator : PowerUpActivator
{
    protected override Evt GetPowerUpEvent() => EventManager.Instance.onBulldozerPowerUp;
}