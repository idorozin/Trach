using System;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public Evt onFlyPowerUp = new Evt();
    public Evt onBulldozerPowerUp = new Evt();
    public Evt onCoinCollected = new Evt();
    public Evt onMissilesCollected = new Evt();
    public Evt<string> onSwipeDetected = new Evt<string>();
    public Evt<int> onMissilesChanged = new Evt<int>();

    private void Awake()
    {
        Instance = this;
    }
}