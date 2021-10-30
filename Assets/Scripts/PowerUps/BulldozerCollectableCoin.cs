using System;
using UnityEngine;


public class BulldozerCollectableCoin : CollectableCoin
{
    public override Evt GetOnCollectEvent() => EventManager.Instance.onBulldozerPowerUp;
}