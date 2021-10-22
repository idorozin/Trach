using System;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public Evt onFlyPowerUp = new Evt();
    public Evt onBulldozerPowerUp = new Evt();

    private void Awake()
    {
        Instance = this;
    }
}