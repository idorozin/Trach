using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaveiour : CollectableCoin
{
    public override Evt GetOnCollectEvent() => EventManager.Instance.onCoinCollected;
}
