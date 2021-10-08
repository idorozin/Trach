using UnityEngine;

public class BulldozerPowerUp : PowerUpBehaviour
{
    public GameObject bulldozer;

    protected override void BeginPowerUp()
    {
       bulldozer.SetActive(true);
    }

    protected override void EndPowerUp()
    {
        bulldozer.SetActive(false);
    }
}