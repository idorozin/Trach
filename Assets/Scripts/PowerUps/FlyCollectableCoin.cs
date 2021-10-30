using System;
using UnityEngine;


public class FlyCollectableCoin :  CollectableCoin
{
    public override Evt GetOnCollectEvent() => EventManager.Instance.onFlyPowerUp;
}
