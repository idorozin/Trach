using System;
using UnityEngine;


public class FlyPowerUpActivator :  PowerUpActivator
{
    protected override Evt GetPowerUpEvent() => EventManager.Instance.onFlyPowerUp;
}
