using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : CollectableCoin
{
    public override Evt GetOnCollectEvent() => EventManager.Instance.onMissilesCollected;
}
